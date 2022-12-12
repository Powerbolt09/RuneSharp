using RuneSharp.Resources;
using RuneSharp.Services.GE.Detail;

namespace RuneSharpTest.Tests.Services.GE.Detail
{
    public class DetailServiceTests
    {
        [Fact]
        void DetailService_Uri()
        {
            DetailService service = new DetailService();

            Assert.Equal("https", service._uriBuilder.Scheme);
            Assert.Equal(Config.RunescapeServices, service._uriBuilder.Host);
            Assert.Equal($"{Config.BasePath}{Config.ExchangeApi}{Config.DetailCatalogue}", service._uriBuilder.Path);
        }
    }
}
