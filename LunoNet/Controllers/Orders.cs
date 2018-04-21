using System;
using System.Threading.Tasks;
using LunoNet.Models;
using LunoNet.Network;
using Newtonsoft.Json;

namespace LunoNet.Controllers
{
    public class Orders
    {

        private HttpClientWrapper _httpClient;
        private Configuration _configuration;

        public Orders(Configuration configuration)
        {
            _configuration = configuration ?? throw new ArgumentException(nameof(Configuration));
        }

        /// <summary>
        /// Returns a list of the most recently placed orders. 
        /// You can specify an optional state=PENDING parameter to restrict the results to only open orders. 
        /// You can also specify the market by using the optional pair parameter. The list is truncated after 100 items.
        /// </summary>
        /// <returns>The orders.</returns>
        public async Task<ApiResponse<Order[]>>ListOrders() => await HttpClient.GetAsync<Order[]>("listorders");

        /// <summary>
        /// Create a new trade order.
        /// </summary>
        /// <returns>The order.</returns>
        /// <param name="request">Request.</param>
        public async Task<ApiResponse<OrderResponseData>>PostOrder(OrderPostData request)
        {
            //these parameters cannot be left null
            if (string.IsNullOrWhiteSpace(request?.Pair)  ||
                string.IsNullOrWhiteSpace(request?.Type)  ||
                string.IsNullOrWhiteSpace(request.Volume) ||
                string.IsNullOrWhiteSpace(request.Price))
            {
                return new ApiResponse<OrderResponseData>(StatusCode.BadRequest);
            }

            return await HttpClient.PostAsync<OrderResponseData>("postorders",JsonConvert.SerializeObject(request));
        }

        /// <summary>
        /// Posts the market order.
        /// </summary>
        /// <returns>The market order.</returns>
        /// <param name="request">Request.</param>
        public async Task<ApiResponse<OrderResponseData>> PostMarketOrder(OrderPostData request)
        {
            //these parameters cannot be left null
            if (string.IsNullOrWhiteSpace(request?.Pair) ||
                string.IsNullOrWhiteSpace(request?.Type) ||
                string.IsNullOrWhiteSpace(request.Volume) ||
                string.IsNullOrWhiteSpace(request.Price))
            {
                return new ApiResponse<OrderResponseData>(StatusCode.BadRequest);
            }

            return await HttpClient.PostAsync<OrderResponseData>("marketorder", JsonConvert.SerializeObject(request));
        }

        /// <summary>
        /// Stops the order.
        /// </summary>
        /// <returns>The order.</returns>
        /// <param name="orderId">Order identifier.</param>
        public async Task<ApiResponse<StopOrderResponse>> StopOrder(string orderId)
        {
            if (string.IsNullOrWhiteSpace(orderId))
                return new ApiResponse<StopOrderResponse>(StatusCode.BadRequest);

            return await HttpClient.PostAsync<StopOrderResponse>("stoporder", JsonConvert.SerializeObject(orderId));
        }

        /// <summary>
        /// Get an order by its id.
        /// </summary>
        /// <returns>The order.</returns>
        /// <param name="orderId">Order identifier.</param>
        public async Task<ApiResponse<Order>> GetOrder(string orderId)
        {
            if (string.IsNullOrWhiteSpace(orderId))
                return new ApiResponse<Order>(StatusCode.BadRequest);

            return await HttpClient.PostAsync<Order>("orders", JsonConvert.SerializeObject(orderId));
        }

        /// <summary>
        /// Returns an instance of the HttpClient.
        /// </summary>
        /// <value>The http client.</value>
        private HttpClientWrapper HttpClient 
        {
            get 
            {
                return _httpClient = (_httpClient = HttpClientWrapper.Create(_configuration));    
            }    
        }
    }
}
