using CGC.Domain.Base;
using Microsoft.EntityFrameworkCore;
using CGC.Domain.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace CGC.Domain.Aggregates.WIT
{
    public class WorkItem
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("rev")]
        public int Rev { get; set; }

        [JsonProperty("fields")]
        public Fields Fields { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

    }
}
