using CGC.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CGC.Domain.Models.ValueObjects
{
    public class Links
    {
        [JsonProperty("avatar")]
        public Avatar Avatar { get; set; }

    }
}
