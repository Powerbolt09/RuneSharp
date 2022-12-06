using Newtonsoft.Json;

namespace RuneSharp.GE.Responses
{
    public class InfoResponse
    {
        [JsonProperty("lastConfigUpdateRuneday")]
        public int RuneDay { get; set; }
    }
}
