using AutoMapper;
using CGC.API.DTO;
using CGC.Domain.Aggregates.WIT;
using CGC.Domain.Models.ValueObjects;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CGC.Domain.Service
{
    public class AzureDomainService : IAzureDomainService
    {
        private HttpClient _client;
        IMapper _mapper;
        private string personalAccessToken;

        
        public AzureDomainService(IMapper mapper, IConfiguration Configuration)
        {
            _mapper = mapper;
            personalAccessToken = Configuration.GetValue<string>("PersonalAccessToken");
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

        public async Task<IEnumerable<WorkItemDto>> GetAll()
        {
            try
            {
                var query = new Query();
                query.query = "Select * From WorkItems Where [System.WorkItemType] = 'Bug' AND [State] <> 'Done' AND [State] <> 'Removed' order by [System.CreatedDate] desc";
                string jsonQuery = JsonConvert.SerializeObject(query);
                StringContent httpContent = new StringContent(jsonQuery, System.Text.Encoding.UTF8, "application/json");
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(String.Format("https://dev.azure.com/rohi42/_apis/wit/wiql?api-version=6.0")),
                    Content = httpContent
                };
                string responseBody = await this.SendRequest(request);
                DevopsWorkItems respObject = JsonConvert.DeserializeObject<DevopsWorkItems>(responseBody);
                List<WorkItemDto> returnValue = new List<WorkItemDto>();
                foreach (var item in respObject.WorkItems)
                {
                    var items = await this.GetById(item.Id.ToString());
                    var itemWithPriority = _mapper.Map(items, _mapper.Map<WorkItemDto>(items.Fields));
                    var ItemsWithAssignTo = _mapper.Map(items.Fields.SystemAssignedTo, itemWithPriority);
                    returnValue.Add(ItemsWithAssignTo);
                }
                return returnValue.AsEnumerable();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<WorkItem> GetById(string id)
        {
            try
            {
                var query = new Query();
                query.query = "Select[System.Id], [System.Title], [System.State] From WorkItems Where[System.WorkItemType] = 'Bug' AND[State] <> 'Done' AND[State] <> 'Removed' order by[System.CreatedDate] desc";
                string jsonQuery = JsonConvert.SerializeObject(query);
                StringContent httpContent = new StringContent(jsonQuery, System.Text.Encoding.UTF8, "application/json");
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(String.Format("https://dev.azure.com/rohi42/_apis/wit/workitems?ids={0}&api-version=6.0", id)),
                    Content = httpContent
                };
                string responseBody = await this.SendRequest(request);
                WorkItemResponse respObject = JsonConvert.DeserializeObject<WorkItemResponse>(responseBody);
                return respObject.Value.FirstOrDefault();
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> DeleteById(string id)
        {
            try
            {
                var updateDocument = new[]
                {
                new { op = "add", path = "/fields/System.State", value = "Removed" },
                new { op = "add", path="/fields/System.History",value="This work item is marked for deletion."}

            };
                string jsonPatch = JsonConvert.SerializeObject(updateDocument);

                // Prepare the HTTP request
                StringContent httpContent = new StringContent(jsonPatch, Encoding.UTF8, "application/json-patch+json");
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Patch,
                    RequestUri = new Uri(String.Format("https://dev.azure.com/rohi42/_apis/wit/workitems/{0}?api-version=7.1-preview.3", id)),
                    Content = httpContent
                };

                // Set authentication headers (assuming you have a method to obtain a PAT)
                string responseBody = await this.SendRequest(request);

                WorkItem respObject = JsonConvert.DeserializeObject<WorkItem>(responseBody);
                if (respObject.Fields.SystemState == "Removed")
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateById(WorkItemDto workItemdto)
        {
            try
            {


                var updateDocument = new[]
                {
                new { op = "add", path = "/fields/System.Title", value = workItemdto.SystemTitle },
                new { op = "add", path = "/fields/Microsoft.VSTS.Common.Priority", value = workItemdto.CommonPriority.ToString() },
                new { op = "add", path = "/fields/Microsoft.VSTS.TCM.ReproSteps", value = workItemdto.TCMReproSteps },
                new { op = "add", path = "/fields/Microsoft.VSTS.Common.Severity", value = workItemdto.CommonSeverity },
                new{  op = "add", path =  "/fields/System.History", value="Updated from DevOps API"}

            };
                string jsonPatch = JsonConvert.SerializeObject(updateDocument);

                // Prepare the HTTP request
                StringContent httpContent = new StringContent(jsonPatch, Encoding.UTF8, "application/json-patch+json");
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Patch,
                    RequestUri = new Uri(String.Format("https://dev.azure.com/rohi42/_apis/wit/workitems/{0}?api-version=7.1-preview.3", workItemdto.Id)),
                    Content = httpContent //ev.azure.com/rohithpeketi/DDD/_workitems/edit/1/
                };

                // Set authentication headers (assuming you have a method to obtain a PAT)
                string responseBody = await this.SendRequest(request);
                WorkItem respObject = JsonConvert.DeserializeObject<WorkItem>(responseBody);
                if (respObject.Rev == workItemdto.Rev + 1) { return true; }
                else { return false; }
            }
            catch(Exception ex) { return false; }
            
        }
        public async Task<bool> DeleteSelected(int[] workItemdtos)
        {
            try
            {
                var updateDocument = new[]
                {
                 new { op = "add", path = "/fields/System.State", value = "Removed" },
                 new { op="add", path="/fields/System.History",value="This work item is marked for deletion."}
            };
                string jsonPatch = JsonConvert.SerializeObject(updateDocument);

                // Prepare the HTTP request
                foreach (var item in workItemdtos)
                {
                    StringContent httpContent = new StringContent(jsonPatch, Encoding.UTF8, "application/json-patch+json");
                    HttpRequestMessage request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Patch,
                        RequestUri = new Uri(String.Format("https://dev.azure.com/rohi42/_apis/wit/workitems/{0}?api-version=7.1-preview.3", item)),
                        Content = httpContent
                    };


                    string responseBody = await this.SendRequest(request);
                }
                //WorkItemResponse respObject = JsonConvert.DeserializeObject<WorkItemResponse>(responseBody);
                // if (respObject != null) { return true; }
                // else { return false; }
                return true;
            }
            catch (Exception ex) { return false; }

        }
        public async Task<bool> CreateItem(WorkItemDto workItemdto)
        {
            try
            {
                var updateDocument = new[]
                {
                new { op = "add", path = "/fields/System.Title", value = workItemdto.SystemTitle },
                new { op = "add", path = "/fields/Microsoft.VSTS.Common.Priority", value = workItemdto.CommonPriority.ToString() },
                new { op = "add", path = "/fields/Microsoft.VSTS.TCM.ReproSteps", value = workItemdto.TCMReproSteps },
                new { op = "add", path = "/fields/Microsoft.VSTS.Common.Severity", value = workItemdto.CommonSeverity }
            };
                string jsonPatch = JsonConvert.SerializeObject(updateDocument);

                // Prepare the HTTP request
                StringContent httpContent = new StringContent(jsonPatch, Encoding.UTF8, "application/json-patch+json");
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri(String.Format("https://dev.azure.com/rohi42/_apis/wit/workitems/$Bug?api-version=6.1-preview.3", "Task")),
                    Content = httpContent
                };

                // Set authentication headers (assuming you have a method to obtain a PAT)
                string responseBody = await this.SendRequest(request);

                var respObject = JsonConvert.DeserializeObject<WorkItem>(responseBody);
                if (respObject.Rev == 1) { return true; }
                else { return false; }
            }
            catch(Exception ex)
            {
                return false; 
            }
            
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