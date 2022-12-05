using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

        public T Send<T>(HttpRequestMessage request)
        {
            return Unmarshall<T>(base.Send(request).Content);
        }

        public async Task<T> SendAsync<T>(HttpRequestMessage request)
        {
            HttpResponseMessage response = await base.SendAsync(request);

            return Unmarshall<T>(response.Content);
        }

        private T Unmarshall<T>(HttpContent content)
        {
            if (content != null)
            {
                using (StreamReader sr = new StreamReader(content.ReadAsStream()))
                {
                    string json = sr.ReadToEnd();

                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        try
                        {
                            // Successful parse. Return populated class object.
                            return JsonConvert.DeserializeObject<T>(json);
                        }
                        catch (Exception ex)
                        {
                            // Log exception to console.
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }

            return default;
        }
    }
}
