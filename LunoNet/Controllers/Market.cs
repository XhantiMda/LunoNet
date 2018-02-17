using System.Threading.Tasks;
using LunoNet.Models;
using LunoNet.Network;


namespace LunoNet.Controllers
{
    /// <summary>
    /// Market data API calls can be accessed by anyone without authentication.
    /// </summary>
    public class Market
    {
        private HttpClientWrapper _httpClient;

        /// <summary>
        /// Returns the latest ticker indicators.
        /// </summary>
        /// <returns>The ticker for pair.</returns>
        /// <param name="pair">Pair.</param>
        public async Task<ApiResponse<Ticker>> GetTickerForPair(string pair)
        {
            var urlString = $"ticker?pair={pair}";

            return await HttpClient.GetAsync<Ticker>(urlString);
        }

        /// <summary>
        /// Gets all tickers for pair.
        /// </summary>
        /// <returns>The all tickers for pair.</returns>
        /// <param name="pair">Pair.</param>
        public async Task<ApiResponse<Ticker[]>> GetAllTickersForPairAsync(string pair)
        {
            var urlString = $"ticker?pair={pair}";

            return await HttpClient.GetAsync<Ticker[]>(urlString);
        }

        /// <summary>
        /// Returns a list of bids and asks in the order book. 
        /// Ask orders are sorted by price ascending. 
        /// Bid orders are sorted by price descending. 
        /// Note that multiple orders at the same price are not necessarily conflated.
        /// </summary>
        /// <returns>The orderbook for pair.</returns>
        /// <param name="pair">Pair.</param>
        public async Task<ApiResponse<Orderbook>> GetOrderbookForPairAsync(string pair)
        {
            var urlString = $"orderbook?pair={pair}";

            return await HttpClient.GetAsync<Orderbook>(urlString);
        }

        /// <summary>
        /// Returns a list of the most recent trades. At most 100 results are returned per call.
        /// </summary>
        /// <returns>The trades for pair async.</returns>
        /// <param name="pair">Pair.</param>
        public async Task<ApiResponse<Trade[]>> GetTradesForPairAsync(string pair)
        {
            var urlString = $"trades?pair={pair}";

            return await HttpClient.GetAsync<Trade[]>(urlString);
        }

        /// <summary>
        /// Returns an instance of the HttpClientWrapper.
        /// </summary>
        /// <value>The http client.</value>
        private HttpClientWrapper HttpClient
        {
            get 
            {
                return _httpClient ?? (_httpClient = HttpClientWrapper.Create());   
            }    
        }

    }
}
