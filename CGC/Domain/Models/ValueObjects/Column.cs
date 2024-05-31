using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CGC.Domain.Models.ValueObjects
{
    public class Column
    {
        [JsonPropertyName("referenceName")]
        public string ReferenceName { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
