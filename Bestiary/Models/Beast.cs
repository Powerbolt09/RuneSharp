using Newtonsoft.Json;

namespace RuneSharp.Bestiary.Models
{
    public class Beast
    {
        [JsonProperty("label")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public int Id { get; set; }
    }
}
