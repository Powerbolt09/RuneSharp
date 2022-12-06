using Newtonsoft.Json;

namespace RuneSharp.Bestiary.Models
{
    public class BeastData
    {
        [JsonProperty("magic")]
        public int Magic { get; set; }

        [JsonProperty("defence")]
        public int Defence { get; set; }

        [JsonProperty("level")]
        public int Level { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("areas")]
        public List<string> Areas { get; set; }

        [JsonProperty("poisonous")]
        public bool Poisonous { get; set; }

        [JsonProperty("weakness")]
        public string Weakness { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("ranged")]
        public int Ranged { get; set; }

        [JsonProperty("attack")]
        public int Attack { get; set; }

        [JsonProperty("members")]
        public bool Members { get; set; }

        [JsonProperty("animations")]
        public BeastDataAnimation Animations { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("xp")]
        public string Experience { get; set; }

        [JsonProperty("slayerlevel")]
        public int SlayerLevel { get; set; }

        [JsonProperty("slayercat")]
        public string SlayerCategory { get; set; }

        [JsonProperty("lifepoints")]
        public int Lifepoints { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("aggressive")]
        public bool Aggressive { get; set; }

        [JsonProperty("attackable")]
        public bool Attackable { get; set; }
    }
}
