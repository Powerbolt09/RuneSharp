using RuneSharp.GE.Responses;
using RuneSharp.Resources;
using RuneSharp.Utils;

namespace RuneSharp.Services.GE.Detail
{
    public class DetailService : BaseSdkService
    {
        public DetailService() : base(Config.ExchangeApi, Config.DetailCatalogue)
        {
        }

        /// <summary>
        /// Details API. Retrieve a summary of item information and price data.
        /// </summary>
        /// <param name="id">Item Id</param>
        /// <returns>DetailResponse</returns>
        public DetailResponse GetItemById(int id)
        {
            return Get<DetailResponse>(
                new QueryStringBuilder()
                    .Add("category", id)
                    .ToString()
            );
        }

        /// <summary>
        /// Details API. Asynchronous. Retrieve a summary of item and price data.
        /// </summary>
        /// <param name="id">Item Id</param>
        /// <returns>Task</returns>
        public async Task<DetailResponse> GetItemByIdAsync(int id)
        {
            return await GetAsync<DetailResponse>(
                new QueryStringBuilder()
                    .Add("category", id)
                    .ToString()
            );
        }
    }
}
