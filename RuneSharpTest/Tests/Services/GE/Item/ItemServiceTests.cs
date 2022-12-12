using RuneSharp.Resources;
using RuneSharp.Services.GE.Item;

namespace RuneSharpTest.Tests.Services.GE.Item
{
    public class ItemServiceTests
    {
        [Fact]
        void ItemService_Uri()
        {
            ItemService service = new ItemService();

            Assert.Equal("https", service._uriBuilder.Scheme);
            Assert.Equal(Config.RunescapeServices, service._uriBuilder.Host);
            Assert.Equal($"{Config.BasePath}{Config.ExchangeApi}{Config.ItemCatalogue}", service._uriBuilder.Path);
        }
    }
}
