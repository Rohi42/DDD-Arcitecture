
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CGC.Domain.Aggregates.WIT
{
    public class WorkItemResponse
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("value")]
        public List<WorkItem> Value { get; set; }
    }
}
