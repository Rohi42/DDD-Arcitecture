using CGC.Domain.Models.ValueObjects;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CGC.Domain.Aggregates.WIT
{
    public class WorkItemResult
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("rev")]
        public int Rev { get; set; }

        [JsonPropertyName("fields")]
        public Fields Fields { get; set; }

        [JsonPropertyName("_links")]
        public Links Links { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
