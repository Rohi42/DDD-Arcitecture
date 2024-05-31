using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CGC.Domain.Models.ValueObjects
{
    public class DevopsWorkItems
    {
        [JsonPropertyName("queryType")]
        public string QueryType { get; set; }

        [JsonPropertyName("queryResultType")]
        public string QueryResultType { get; set; }

        [JsonPropertyName("asOf")]
        public DateTime AsOf { get; set; }

        [JsonPropertyName("columns")]
        public List<Column> Columns { get; set; }

        [JsonPropertyName("sortColumns")]
        public List<SortColumn> SortColumns { get; set; }

        [JsonPropertyName("workItems")]
        public List<DevopsWorkItem> WorkItems { get; set; }
    }
}
