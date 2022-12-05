using Newtonsoft.Json;

namespace RuneSharp.Utils
{
    public sealed class HttpClientWrapper : HttpClient
    {
        private static readonly HttpClientWrapper _http = new HttpClientWrapper();

        public static HttpClientWrapper Client
        {
            get
            {
                return _http;
            }
        }

        /// <summary>
        /// Executes an HTTP request, and deserializes the response to an object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns>T</returns>
        /// <exception cref="HttpRequestException"></exception>
        public T Send<T>(HttpRequestMessage request)
        {
            HttpResponseMessage response = Send(request);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    return Unmarshall<T>(response.Content);
                } 
                catch (Exception ex)
                {
                    throw new HttpRequestException(ex.Message, ex, response.StatusCode);
                }
            }

            throw new HttpRequestException($"{request.Method} {request.RequestUri} failed.", null, response.StatusCode);
        }

        /// <summary>
        /// Async. Executes an HTTP request, and deserializes the response to an object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns>Asynchronous Task of T</returns>
        /// <exception cref="HttpRequestException"></exception>
        public async Task<T> SendAsync<T>(HttpRequestMessage request)
        {
            HttpResponseMessage response = await SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    return Unmarshall<T>(response.Content);
                }
                catch (Exception ex)
                {
                    throw new HttpRequestException(ex.Message, ex, response.StatusCode);
                }
            }

            throw new HttpRequestException($"{request.Method} {request.RequestUri} failed.", null, response.StatusCode);
        }

        /// <summary>
        /// Deserializes response stream to object.
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="content">Response</param>
        /// <returns>T</returns>
        /// <exception cref="JsonSerializationException"></exception>
        private T Unmarshall<T>(HttpContent content)
        {
            if (content != null)
            {
                using (StreamReader sr = new StreamReader(content.ReadAsStream()))
                {
                    string json = sr.ReadToEnd();

                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        T? result = JsonConvert.DeserializeObject<T>(json);

                        if (result != null)
                        {
                            // Successful parse. Return populated class object.
                            return result;
                        }
                    }
                }
            }

            throw new JsonSerializationException($"Response unmarshalling failed.\r\nContent: {(content == null ? "[NULL]" : content.ToString())}");
        }
    }
}
