using RuneSharp.Bestiary.Models;

namespace RuneSharp.Bestiary.Responses
{
    public class BeastNameResponse
    {
        public List<Beast> Beasts { get; set; }

        public List<GroupedBeast> GroupedBeasts { get; set; }
    }
}
