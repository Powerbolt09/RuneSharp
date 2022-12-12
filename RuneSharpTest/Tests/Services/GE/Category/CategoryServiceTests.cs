using RuneSharp.Resources;
using RuneSharp.Services.GE.Category;

namespace RuneSharpTest.Tests.Services.GE.Category
{
    public class CategoryServiceTests
    {
        [Fact]
        void CategoryService_Uri()
        {
            CategoryService service = new CategoryService();

            Assert.Equal("https", service._uriBuilder.Scheme);
            Assert.Equal(Config.RunescapeServices, service._uriBuilder.Host);
            Assert.Equal($"{Config.BasePath}{Config.ExchangeApi}{Config.CategoryCatalogue}", service._uriBuilder.Path);
        }
    }
}
