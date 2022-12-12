using RuneSharp.Resources;
using RuneSharp.Services.GE.Info;

namespace RuneSharpTest.Tests.Services.GE.Info
{
    public class InfoServiceTests
    {
        [Fact]
        void InfoService_Uri()
        {
            InfoService service = new InfoService();

            Assert.Equal("https", service._uriBuilder.Scheme);
            Assert.Equal(Config.RunescapeServices, service._uriBuilder.Host);
            Assert.Equal($"{Config.BasePath}{Config.ExchangeApi}{Config.InfoCatalogue}", service._uriBuilder.Path);
        }
    }
}
