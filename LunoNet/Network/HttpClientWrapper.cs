using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using LunoNet.Helpers;

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
        /// <param name="configuration">Configuration.</param>
        public static HttpClientWrapper Create(Configuration configuration = null)
        {
            _httpClient = new HttpClient();

            _httpClient.DefaultRequestHeaders
                       .Accept
                       .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (configuration != null)
            {
                var encodedCredentials = StringHelper.ConvertToBase64($"{configuration.Api_Key_Id}:{configuration.Api_Key_Secret}");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", encodedCredentials);
            }

            return new HttpClientWrapper();
        }

        /// <summary>
        /// Gets data from remote api asynchronously.
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="url">URL.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public async Task<ApiResponse<T>> GetAsync<T>(string url) where T : class => await SendRequest<T>(RequestType.GET, url);

        /// <summary>
        /// Posts payload to remote api asynchronously.
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="url">URL.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public async Task<ApiResponse<T>> PostAsync<T>(string url, string content) where T : class => await SendRequest<T>(RequestType.POST, url, content);

        /// <summary>
        /// Deletes async.
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="url">URL.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public async Task<ApiResponse<T>> DeleteAsync<T>(string url) where T : class => await SendRequest<T>(RequestType.DELETE, url);

        /// <summary>
        /// Sends the request.
        /// </summary>
        /// <returns>The request.</returns>
        /// <param name="requestType">Request type.</param>
        /// <param name="url">URL.</param>
        /// <param name="content">Content.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        private async Task<ApiResponse<T>> SendRequest<T>(RequestType requestType, string url, string content = null) where T : class
        {
            var response = default(HttpResponseMessage);

            try
            {
                switch (requestType)
                {
                    case RequestType.GET:
                        response = await _httpClient.GetAsync($"{_baseUrl}{url}");
                        break;
                    case RequestType.POST:
                        response = await _httpClient.PostAsync($"{_baseUrl}{url}", new StringContent(content));
                        break;
                    case RequestType.DELETE:
                        response = await _httpClient.DeleteAsync($"{_baseUrl}{url}");
                        break;
                }

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    return new ApiResponse<T>((StatusCode)response.StatusCode);

                var rawData = await response.Content.ReadAsStringAsync();

                var data = JsonConvert.DeserializeObject<T>(rawData);

                return new ApiResponse<T>((StatusCode)response.StatusCode, data, rawData);

            }
            catch
            {
                if (response != null)
                    return new ApiResponse<T>((StatusCode)response.StatusCode);

                return new ApiResponse<T>(StatusCode.BadGateway);
            }
        }

    }
}
