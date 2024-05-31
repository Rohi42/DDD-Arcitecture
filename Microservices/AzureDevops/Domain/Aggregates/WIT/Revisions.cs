using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureDevops.Domain.Aggregates.WIT
{
    public class Revisions
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("value")]
        public List<WorkItem> Value { get; set; }
    }
}
