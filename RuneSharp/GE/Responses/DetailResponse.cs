using Newtonsoft.Json;
using RuneSharp.GE.Models;

namespace RuneSharp.GE.Responses
{
    public class DetailResponse
    {
        [JsonProperty("item")]
        public Item Item { get; set; } = new Item();
    }
}
