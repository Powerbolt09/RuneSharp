using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuneSharp.GE.Models
{
    public class Category
    {
        [JsonProperty("letter")]
        public string Letter { get; set; }

        [JsonProperty("items")]
        public int Items { get; set; }
    }
}
