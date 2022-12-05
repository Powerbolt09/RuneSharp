using RuneSharp.GE.Enums;
using RuneSharp.GE.Models;
using RuneSharp.Resources;
using RuneSharp.Utils;

namespace RuneSharp.Services.GE.Item
{
    public class ItemService : BaseSdkService
    {
        public ItemService() : base(Config.ExchangeApi, Config.ItemCatalogue)
        {
        }

        /// <summary>
        /// Items API. Retrieve a list of summarized item and price data.
        /// </summary>
        /// <param name="categoryId">Category Id</param>
        /// <param name="leadChar">Leading Character</param>
        /// <param name="page">Page</param>
        /// <returns>ItemResponse</returns>
        public ItemResponse GetItemListByCategory(int categoryId, string leadChar, int page)
        {
            if (!string.IsNullOrWhiteSpace(leadChar))
            {
                return Get<ItemResponse>(
                    new QueryStringBuilder()
                        .Add("category", categoryId.ToString())
                        .Add("alpha", leadChar)
                        .Add("page", page.ToString())
                        .ToString()
                );
            }

            return new ItemResponse();
        }

        /// <summary>
        /// Items API. Retrieve a list of summarized item and price data.
        /// </summary>
        /// <param name="categoryId">Category Id</param>
        /// <param name="leadChar">Leading Character</param>
        /// <param name="page">Page</param>
        /// <returns>ItemResponse</returns>
        public ItemResponse GetItemListByCategory(int categoryId, char leadChar, int page)
        {
            return GetItemListByCategory(categoryId, leadChar.ToString(), page);
        }

        /// <summary>
        /// Items API. Retrieve a list of summarized item and price data.
        /// </summary>
        /// <param name="categoryId">Category Id</param>
        /// <param name="leadChar">Leading Character</param>
        /// <param name="page">Page</param>
        /// <returns>ItemResponse</returns>
        public ItemResponse GetItemListByCategory(CategoryId categoryId, string leadChar, int page)
        {
            return GetItemListByCategory((int)categoryId, leadChar, page);
        }

        /// <summary>
        /// Items API. Retrieve a list of summarized item and price data.
        /// </summary>
        /// <param name="categoryId">Category Id</param>
        /// <param name="leadChar">Leading Character</param>
        /// <param name="page">Page</param>
        /// <returns>ItemResponse</returns>
        public ItemResponse GetItemListByCategory(CategoryId categoryId, char leadChar, int page)
        {
            return GetItemListByCategory((int)categoryId, leadChar.ToString(), page);
        }

        /// <summary>
        /// Items API. Retrieve a list of summarized item and price data.
        /// </summary>
        /// <param name="categoryId">Category Id</param>
        /// <param name="leadChar">Leading Character</param>
        /// <returns>ItemResponse</returns>
        public ItemResponse GetItemListByCategory(int categoryId, string leadChar)
        {
            if (!string.IsNullOrWhiteSpace(leadChar))
            {
                return Get<ItemResponse>(
                    new QueryStringBuilder()
                        .Add("category", categoryId.ToString())
                        .Add("alpha", leadChar)
                        .ToString()
                );
            }

            return new ItemResponse();
        }

        /// <summary>
        /// Items API. Retrieve a list of summarized item and price data.
        /// </summary>
        /// <param name="categoryId">Category Id</param>
        /// <param name="leadChar">Leading Character</param>
        /// <returns>ItemResponse</returns>
        public ItemResponse GetItemListByCategory(int categoryId, char leadChar)
        {
            return GetItemListByCategory(categoryId, leadChar.ToString());
        }

        /// <summary>
        /// Items API. Retrieve a list of summarized item and price data.
        /// </summary>
        /// <param name="categoryId">Category Id</param>
        /// <param name="leadChar">Leading Character</param>
        /// <returns>ItemResponse</returns>
        public ItemResponse GetItemListByCategory(CategoryId categoryId, string leadChar)
        {
            return GetItemListByCategory((int)categoryId, leadChar);
        }

        /// <summary>
        /// Items API. Retrieve a list of summarized item and price data.
        /// </summary>
        /// <param name="categoryId">Category Id</param>
        /// <param name="leadChar">Leading Character</param>
        /// <returns>ItemResponse</returns>
        public ItemResponse GetItemListByCategory(CategoryId categoryId, char leadChar)
        {
            return GetItemListByCategory((int)categoryId, leadChar.ToString());
        }

        /// <summary>
        /// Items API. Asynchronous. Retrieve a list of summarized item and price data.
        /// </summary>
        /// <param name="categoryId">Category Id</param>
        /// <param name="leadChar">Leading Character</param>
        /// <param name="page">Page</param>
        /// <returns>Task</returns>
        public async Task<ItemResponse> GetItemListByCategoryAsync(int categoryId, string leadChar, int page)
        {
            if (!string.IsNullOrWhiteSpace(leadChar))
            {
                return await GetAsync<ItemResponse>(
                    new QueryStringBuilder()
                        .Add("category", categoryId.ToString())
                        .Add("alpha", leadChar)
                        .Add("page", page.ToString())
                        .ToString()
                );
            }

            return new ItemResponse();
        }

        /// <summary>
        /// Items API. Asynchronous. Retrieve a list of summarized item and price data.
        /// </summary>
        /// <param name="categoryId">Category Id</param>
        /// <param name="leadChar">Leading Character</param>
        /// <param name="page">Page</param>
        /// <returns>Task</returns>
        public async Task<ItemResponse> GetItemListByCategoryAsync(int categoryId, char leadChar, int page)
        {
            return await GetItemListByCategoryAsync(categoryId, leadChar.ToString(), page);
        }

        /// <summary>
        /// Items API. Asynchronous. Retrieve a list of summarized item and price data.
        /// </summary>
        /// <param name="categoryId">Category Id</param>
        /// <param name="leadChar">Leading Character</param>
        /// <param name="page">Page</param>
        /// <returns>Task</returns>
        public async Task<ItemResponse> GetItemListByCategoryAsync(CategoryId categoryId, string leadChar, int page)
        {
            return await GetItemListByCategoryAsync((int)categoryId, leadChar, page);
        }

        /// <summary>
        /// Items API. Asynchronous. Retrieve a list of summarized item and price data.
        /// </summary>
        /// <param name="categoryId">Category Id</param>
        /// <param name="leadChar">Leading Character</param>
        /// <param name="page">Page</param>
        /// <returns>Task</returns>
        public async Task<ItemResponse> GetItemListByCategoryAsync(CategoryId categoryId, char leadChar, int page)
        {
            return await GetItemListByCategoryAsync((int)categoryId, leadChar.ToString(), page);
        }

        /// <summary>
        /// Items API. Asynchronous. Retrieve a list of summarized item and price data.
        /// </summary>
        /// <param name="categoryId">Category Id</param>
        /// <param name="leadChar">Leading Character</param>
        /// <returns>Task</returns>
        public async Task<ItemResponse> GetItemListByCategoryAsync(int categoryId, string leadChar)
        {
            if (!string.IsNullOrWhiteSpace(leadChar))
            {
                return await GetAsync<ItemResponse>(
                    new QueryStringBuilder()
                        .Add("category", categoryId.ToString())
                        .Add("alpha", leadChar)
                        .ToString()
                );
            }

            return new ItemResponse();
        }

        /// <summary>
        /// Items API. Asynchronous. Retrieve a list of summarized item and price data.
        /// </summary>
        /// <param name="categoryId">Category Id</param>
        /// <param name="leadChar">Leading Character</param>
        /// <returns>Task</returns>
        public async Task<ItemResponse> GetItemListByCategoryAsync(int categoryId, char leadChar)
        {
            return await GetItemListByCategoryAsync(categoryId, leadChar.ToString());
        }

        /// <summary>
        /// Items API. Asynchronous. Retrieve a list of summarized item and price data.
        /// </summary>
        /// <param name="categoryId">Category Id</param>
        /// <param name="leadChar">Leading Character</param>
        /// <returns>Task</returns>
        public async Task<ItemResponse> GetItemListByCategoryAsync(CategoryId categoryId, string leadChar)
        {
            return await GetItemListByCategoryAsync((int)categoryId, leadChar);
        }

        /// <summary>
        /// Items API. Asynchronous. Retrieve a list of summarized item and price data.
        /// </summary>
        /// <param name="categoryId">Category Id</param>
        /// <param name="leadChar">Leading Character</param>
        /// <returns>Task</returns>
        public async Task<ItemResponse> GetItemListByCategoryAsync(CategoryId categoryId, char leadChar)
        {
            return await GetItemListByCategoryAsync((int)categoryId, leadChar.ToString());
        }
    }
}
