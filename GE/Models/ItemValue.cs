using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuneSharp.GE.Models
{
    public class ItemValue
    {
        [JsonProperty("trend")]
        public string Trend { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }
    }
}
