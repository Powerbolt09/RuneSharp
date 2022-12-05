using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuneSharp.Bestiary.Models
{
    public class BeastSearch
    {
        [JsonProperty("label")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public int Id { get; set; }
    }
}
