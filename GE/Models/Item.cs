using Newtonsoft.Json;

namespace RuneSharp.GE.Models
{
    public class Item
    {
        [JsonProperty("icon")]
        public string IconUrl { get; set; }

        [JsonProperty("icon_large")]
        public string LargeIconUrl { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("typeIcon")]
        public string TypeIconUrl { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("current")]
        public ItemValue Current { get; set; }

        [JsonProperty("today")]
        public ItemValue Today { get; set; }

        [JsonProperty("members")]
        public string IsMembers { get; set; }

        [JsonProperty("day30")]
        public ItemTrend TrendOneMonth { get; set; }

        [JsonProperty("day90")]
        public ItemTrend TrendThreeMonths { get; set; }

        [JsonProperty("day180")]
        public ItemTrend TrendSixMonths { get; set; }
    }
}
