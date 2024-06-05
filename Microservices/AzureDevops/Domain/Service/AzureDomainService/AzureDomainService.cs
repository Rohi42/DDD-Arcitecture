using AzureDevops.Domain.Aggregates.WIT;
using AzureDevops.Domain.Models.ValueObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AzureDevops.Domain.Service
{
    public class AzureDomainService : IAzureDomainService
    {
        private HttpClient _client;
        private String personalAccessToken = "";

        public AzureDomainService()
        {
            init();
        }

        public void init()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Add(
                                new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                        Convert.ToBase64String(
                            System.Text.ASCIIEncoding.ASCII.GetBytes(
                                string.Format("{0}:{1}", "", personalAccessToken))));
            _client.DefaultRequestHeaders.Add("api-version", "6.0");
        }

        public async Task<IEnumerable<WorkItem>> GetAll()
        {
            var query = new Query();
            query.query = "Select [System.Id], [System.Title], [System.State] From WorkItems Where [System.WorkItemType] = 'Bug' AND [State] <> 'Done' AND [State] <> 'Removed' order by [System.CreatedDate] desc";
            string jsonQuery = JsonConvert.SerializeObject(query);
            StringContent httpContent = new StringContent(jsonQuery, System.Text.Encoding.UTF8, "application/json");
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(String.Format("https://dev.azure.com/cgc-develop/developer-assessment/_apis/wit/wiql?api-version=6.0")),
                Content = httpContent
            };
            string responseBody = await this.SendRequest(request);
            DevopsWorkItems respObject = JsonConvert.DeserializeObject<DevopsWorkItems>(responseBody);
            List<WorkItem> returnValue = new List<WorkItem>();
            foreach (var item in respObject.WorkItems)
            {
                var workItem = await this.GetById(item.Id.ToString());
                returnValue.Add(workItem);
            }
            return returnValue.AsEnumerable();
        }

        public async Task<WorkItem> GetById(string id)
        {
            var query = new Query();
            query.query = "Select[System.Id], [System.Title], [System.State] From WorkItems Where[System.WorkItemType] = 'Bug' AND[State] <> 'Done' AND[State] <> 'Removed' order by[System.CreatedDate] desc";
            string jsonQuery = JsonConvert.SerializeObject(query);
            StringContent httpContent = new StringContent(jsonQuery, System.Text.Encoding.UTF8, "application/json");
            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(String.Format("https://dev.azure.com/cgc-develop/developer-assessment/_apis/wit/workitems?ids={0}&api-version=6.0", id)),
                Content = httpContent
            };
            string responseBody = await this.SendRequest(request);
            WorkItemResponse respObject = JsonConvert.DeserializeObject<WorkItemResponse>(responseBody);
            return respObject.Value.FirstOrDefault();
        }



        private async Task<String> SendRequest(HttpRequestMessage request)
        {

            HttpResponseMessage response = null;
            try
            {
                response = await _client.SendAsync(request);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return await response.Content.ReadAsStringAsync();
        }
    }
}
