using RuneSharp.Resources;
using RuneSharp.Utils;

namespace RuneSharp.Services
{
    public class BaseSdkService
    {
        protected UriBuilder _uriBuilder;

        protected BaseSdkService(string api, string catalogue)
        {
            _uriBuilder = new UriBuilder()
            {
                Scheme = "https",
                Host = Config.RunescapeServices,
                Path = $"{Config.BasePath}{api}{catalogue}"
            };
        }

        /// <summary>
        /// Send a GET request with the underlying URI object and query string.
        /// </summary>
        /// <typeparam name="T">Response Object Type</typeparam>
        /// <param name="query">URI Query String</param>
        /// <returns>T</returns>
        protected T Get<T>(string query)
        {
            _uriBuilder.Query = query;

            return HttpClientWrapper.Client.Send<T>(
                new HttpRequestMessage(
                    HttpMethod.Get,
                    _uriBuilder.Uri
                )
            );
        }

        /// <summary>
        /// Send a GET request with the underlying URI object.
        /// </summary>
        /// <typeparam name="T">Response Object Type</typeparam>
        /// <returns>T</returns>
        protected T Get<T>()
        {
            return Get<T>(string.Empty);
        }

        /// <summary>
        /// Asynchronous. Send a GET request with the underlying URI object and query string.
        /// </summary>
        /// <typeparam name="T">Response Object Type</typeparam>
        /// <param name="query">URI Query String</param>
        /// <returns>T</returns>
        protected async Task<T> GetAsync<T>(string query)
        {
            _uriBuilder.Query = query;

            return await HttpClientWrapper.Client.SendAsync<T>(
                new HttpRequestMessage(
                    HttpMethod.Get,
                    _uriBuilder.Uri
                )
            );
        }

        /// <summary>
        /// Asynchronous. Send a GET request with the underlying URI object.
        /// </summary>
        /// <typeparam name="T">Response Object Type</typeparam>
        /// <returns>T</returns>
        protected async Task<T> GetAsync<T>()
        {
            return await GetAsync<T>(string.Empty);
        }
    }
}
