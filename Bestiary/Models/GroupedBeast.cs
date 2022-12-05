using Newtonsoft.Json;

namespace RuneSharp.Bestiary.Models
{
    public class GroupedBeast
    {
        [JsonProperty("npcs")]
        public List<Beast> Beasts { get; set; }

        [JsonProperty("dupe")]
        public string Name { get; set; }
    }
}
