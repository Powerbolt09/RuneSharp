using Newtonsoft.Json;
using RuneSharp.GE.Models;

namespace RuneSharp.GE.Responses
{
    public class CategoryResponse
    {
        [JsonProperty("alpha")]
        public List<Category> Categories { get; set; } = new List<Category>();
    }
}
