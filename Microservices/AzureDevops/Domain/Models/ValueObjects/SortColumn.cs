using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AzureDevops.Domain.Models.ValueObjects
{
    public class SortColumn
    {
        [JsonPropertyName("field")]
        public Field Field { get; set; }

        [JsonPropertyName("descending")]
        public bool Descending { get; set; }
    }
}
