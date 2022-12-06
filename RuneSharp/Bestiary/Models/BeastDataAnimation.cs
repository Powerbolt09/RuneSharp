using Newtonsoft.Json;

namespace RuneSharp.Bestiary.Models
{
    public class BeastDataAnimation
    {
        [JsonProperty("death")]
        public int Death { get; set; }

        [JsonProperty("attack")]
        public int Attack { get; set; }
    }
}
