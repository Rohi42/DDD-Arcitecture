using CGC.Domain.Base;
using Newtonsoft.Json;

namespace CGC.API.DTO
{
    public class WorkItemDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("System.Title")]
        public string SystemTitle { get; set; }

        [JsonProperty("Microsoft.VSTS.Common.Priority")]
        public int CommonPriority { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("Microsoft.VSTS.TCM.ReproSteps")]
        public string TCMReproSteps { get; set; }

        [JsonProperty("Microsoft.VSTS.Common.Severity")]
        public string CommonSeverity { get; set; }

        [JsonProperty("select")]
        public bool select { get; set; }

        [JsonProperty("rev")]
        public int Rev { get; set; }

    }
}
