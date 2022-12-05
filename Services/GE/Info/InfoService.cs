using RuneSharp.GE.Responses;
using RuneSharp.Resources;
using RuneSharp.Utils;

namespace RuneSharp.Services.GE.Info
{
    public class InfoService : BaseSdkService
    {
        public InfoService() : base(Config.ExchangeApi, Config.InfoCatalogue)
        {
        }

        /// <summary>
        /// Info API. Retrieve RuneDate.
        /// </summary>
        /// <returns>InfoResponse</returns>
        public InfoResponse GetRuneDate()
        {
            return Get<InfoResponse>();
        }

        /// <summary>
        /// Info API. Asynchronous. Retrieve RuneDate.
        /// </summary>
        /// <returns>Task</returns>
        public async Task<InfoResponse> GetRuneDateAsync()
        {
            return await GetAsync<InfoResponse>();
        }
    }
}
