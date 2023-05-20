using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuneSharp.GE.Models
{
    public class ItemTrend
    {
        [JsonProperty("trend")]
        public string? Trend { get; set; }

        [JsonProperty("change")]
        public string? Change { get; set; }
    }
}
