using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LunoNet.Network
{
    internal class HttpClientWrapper
    {
        private static HttpClient _httpClient;
        private string _baseUrl = "https://api.mybitx.com/api/1/";

        private HttpClientWrapper()
        {
        }

        /// <summary>
        /// Create an instance of the HttpWrapper.
        /// </summary>
        /// <returns>The create.</returns>
        /// <param name="headers">Headers.</param>
        public static HttpClientWrapper Create(Dictionary<string, string> headers = null)
        {
            _httpClient = new HttpClient();

            if (headers != null && headers.Count > 0)
            {
                foreach (var header in headers)
                {
                    _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }

            return new HttpClientWrapper();
        }

        /// <summary>
        /// Gets data from remote api asynchronously.
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="url">URL.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public async Task<T> GetAsync<T>(string url) where T : class
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}{url}");

            var data = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());

            if (data == null)
            {
                return null;
            }

            return data;
        }

        /// <summary>
        /// Posts payload to remote api asynchronously.
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="url">URL.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public async Task<T> PostAsync<T>(string url, string content) where T : class
        {
            var fullUrl = $"{_baseUrl}{url}";

            var response = await _httpClient.PostAsync(fullUrl, new StringContent(content));

            var data = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());

            if (data == null)
            {
                return null;
            }

            return data;
        }
    }
}
