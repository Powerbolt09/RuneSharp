using Newtonsoft.Json;

namespace RuneSharp.GE.Models
{
    public class ItemResponse
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("items")]
        public List<Item> Items { get; set; } = new List<Item>();
    }
}
