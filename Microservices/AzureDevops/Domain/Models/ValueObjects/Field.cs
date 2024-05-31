﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AzureDevops.Domain.Models.ValueObjects
{
    public class Field
    {
        [JsonPropertyName("referenceName")]
        public string ReferenceName { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
