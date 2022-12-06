using RuneSharp.GE.Enums;
using RuneSharp.GE.Responses;
using RuneSharp.Resources;
using RuneSharp.Utils;

namespace RuneSharp.Services.GE.Category
{
    public class CategoryService : BaseSdkService
    {
        public CategoryService() : base(Config.ExchangeApi, Config.CategoryCatalogue)
        {
        }

        /// <summary>
        /// Categories API. Retrieve a category manifest identifying, alphabetically, how many items exist.
        /// </summary>
        /// <param name="id">Category Id</param>
        /// <returns>CategoryResponse</returns>
        private CategoryResponse GetItemCountByCategory(int id)
        {
            return Get<CategoryResponse>(
                new QueryStringBuilder()
                    .Add("category", id)
                    .ToString()
            );
        }

        /// <summary>
        /// Categories API. Retrieve a category manifest identifying, alphabetically, how many items exist.
        /// </summary>
        /// <param name="id">Category Id</param>
        /// <returns>CategoryResponse</returns>
        public CategoryResponse GetItemCountByCategory(CategoryId id)
        {
            return GetItemCountByCategory((int)id);
        }

        /// <summary>
        /// Categories API. Asynchronous. Retrieve a category manifest identifying, alphabetically, how many items exist.
        /// </summary>
        /// <param name="id">Category Id</param>
        /// <returns>Task</returns>
        private async Task<CategoryResponse> GetItemCountByCategoryAsync(int id)
        {
            return await GetAsync<CategoryResponse>(
                new QueryStringBuilder()
                    .Add("category", id)
                    .ToString()
            );
        }

        /// <summary>
        /// Categories API. Asynchronous. Retrieve a category manifest identifying, alphabetically, how many items exist.
        /// </summary>
        /// <param name="id">Category Id</param>
        /// <returns>Task</returns>
        public async Task<CategoryResponse> GetItemCountByCategoryAsync(CategoryId id)
        {
            return await GetItemCountByCategoryAsync((int)id);
        }
    }
}
