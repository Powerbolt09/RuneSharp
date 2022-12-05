using RuneSharp.Bestiary.Models;
using RuneSharp.Bestiary.Responses;
using RuneSharp.Resources;
using RuneSharp.Utils;
using System.Web;

namespace RuneSharp.Services
{
    /*public class BestiaryService : BaseSdkService
    {
        public BestiaryService() : base(Config.BestiaryApi, "")
        {

        }

        /// <summary>
        /// Bestiary API. Retrieve a Beast's data by their ID.
        /// </summary>
        /// <param name="id">Beast ID</param>
        /// <returns>BeastData</returns>
        public BeastData GetBeastById(int id)
        {
            return HttpClientWrapper.Client.Send<BeastData>(
                new HttpRequestMessage(
                    HttpMethod.Get,
                    string.Format("{0}/{1}?beastid={2}", _apiUrl, Config.BeastDataCatalogue, id)
                )
            );
        }

        /// <summary>
        /// Bestiary API. Asynchronous. Retrieve a Beast's data by their ID.
        /// </summary>
        /// <param name="id">Beast ID</param>
        /// <returns>Task<BeastData></returns>
        public async Task<BeastData> GetBeastByIdAsync(int id)
        {
            return await HttpClientWrapper.Client.SendAsync<BeastData>(
                new HttpRequestMessage(
                    HttpMethod.Get,
                    string.Format("{0}/{1}?beastid={2}", _apiUrl, Config.BeastDataCatalogue, id)
                )
            );
        }

        /// <summary>
        /// Bestiary API. Retrieve a list of beasts, and their IDs, whose name matches the search criteria.
        /// </summary>
        /// <param name="name">Beast Name</param>
        /// <returns>List<BeastSearch></returns>
        public List<BeastSearch> SearchBeast(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                return HttpClientWrapper.Client.Send<List<BeastSearch>>(
                    new HttpRequestMessage(
                        HttpMethod.Get,
                        string.Format("{0}/{1}?term={2}", _apiUrl, Config.BeastSearchCatalogue, name)
                    )
                );
            }

            return new List<BeastSearch>();
        }

        /// <summary>
        /// Bestiary API. Retrieve a list of beasts, and their IDs, whose name matches the search criteria.
        /// </summary>
        /// <param name="name">Beast Name</param>
        /// <returns>Task<List<BeastSearch>></returns>
        public async Task<List<BeastSearch>> SearchBeastAsync(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                return await HttpClientWrapper.Client.SendAsync<List<BeastSearch>>(
                    new HttpRequestMessage(
                        HttpMethod.Get,
                        string.Format("{0}/{1}?term={2}", _apiUrl, Config.BeastSearchCatalogue, name)
                    )
                );
            }

            return new List<BeastSearch>();
        }

        /// <summary>
        /// Bestiary API. Retrieve a list of beasts whose name starts with a specific character.
        /// </summary>
        /// <param name="ch">First letter of beast name</param>
        /// <returns>BeastNameResponse</returns>
        public BeastNameResponse SearchBeastByChar(string ch)
        {
            if (!string.IsNullOrWhiteSpace(ch))
            {
                return HttpClientWrapper.Client.Send<BeastNameResponse>(
                    new HttpRequestMessage(
                        HttpMethod.Get,
                        string.Format("{0}/{1}?letter={2}", _apiUrl, Config.BeastNamesCatalogue, ch.First())
                    )
                );
            }

            return new BeastNameResponse();
        }

        /// <summary>
        /// Bestiary API. Retrieve a list of beasts whose name starts with a specific character.
        /// </summary>
        /// <param name="ch">First letter of beast name</param>
        /// <returns>BeastNameResponse</returns>
        public BeastNameResponse SearchBeastByChar(char ch)
        {
            return SearchBeastByChar(ch.ToString());
        }

        /// <summary>
        /// Bestiary API. Asynchronous. Retrieve a list of beasts whose name starts with a specific character.
        /// </summary>
        /// <param name="ch">First letter of beast name</param>
        /// <returns>BeastNameResponse</returns>
        public async Task<BeastNameResponse> SearchBeastByCharAsync(string ch)
        {
            if (!string.IsNullOrWhiteSpace(ch))
            {
                return await HttpClientWrapper.Client.SendAsync<BeastNameResponse>(
                    new HttpRequestMessage(
                        HttpMethod.Get,
                        string.Format("{0}/{1}?letter={2}", _apiUrl, Config.BeastNamesCatalogue, ch.First())
                    )
                );
            }

            return new BeastNameResponse();
        }

        /// <summary>
        /// Bestiary API. Asynchronous. Retrieve a list of beasts whose name starts with a specific character.
        /// </summary>
        /// <param name="ch">First letter of beast name</param>
        /// <returns>BeastNameResponse</returns>
        public async Task<BeastNameResponse> SearchBeastByCharAsync(char ch)
        {
            return await SearchBeastByCharAsync(ch.ToString());
        }

        /// <summary>
        /// Bestiary API. Retrieve a list of areas where beasts can be found.
        /// </summary>
        /// <returns>List</returns>
        public List<string> GetAreas()
        {
            return HttpClientWrapper.Client.Send<List<string>>(
                new HttpRequestMessage(
                    HttpMethod.Get,
                    string.Format("{0}/{1}", _apiUrl, Config.BeastDataCatalogue)
                )
            );
        }

        /// <summary>
        /// Bestiary API. Asynchronous. Retrieve a list of areas where beasts can be found.
        /// </summary>
        /// <returns>List</returns>
        public async Task<List<string>> GetAreasAsync()
        {
            return await HttpClientWrapper.Client.SendAsync<List<string>>(
                new HttpRequestMessage(
                    HttpMethod.Get,
                    string.Format("{0}/{1}", _apiUrl, Config.BeastDataCatalogue)
                )
            );
        }

        /// <summary>
        /// Bestiary API. Retrieve a list of beasts that exist in a specific area.
        /// </summary>
        /// <param name="area"></param>
        /// <returns>List</returns>
        public List<Beast> GetBeastsByArea(string area)
        {
            if (!string.IsNullOrWhiteSpace(area))
            {
                return HttpClientWrapper.Client.Send<List<Beast>>(
                    new HttpRequestMessage(
                        HttpMethod.Get,
                        string.Format("{0}/{1}?identifier={2}", _apiUrl, Config.BeastAreasCatalogue, HttpUtility.UrlEncode(area))
                    )
                );
            }

            return new List<Beast>();
        }

        /// <summary>
        /// Bestiary API. Asynchronous. Retrieve a list of beasts that exist in a specific area.
        /// </summary>
        /// <param name="area"></param>
        /// <returns>List</returns>
        public List<Beast> GetBeastsByAreaAsync(string area)
        {
            if (!string.IsNullOrWhiteSpace(area))
            {
                return HttpClientWrapper.Client.Send<List<Beast>>(
                    new HttpRequestMessage(
                        HttpMethod.Get,
                        string.Format("{0}/{1}?identifier={2}", _apiUrl, Config.BeastAreasCatalogue, HttpUtility.UrlEncode(area))
                    )
                );
            }

            return new List<Beast>();
        }
    }*/
}
