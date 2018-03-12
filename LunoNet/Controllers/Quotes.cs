using System;
using System.Threading.Tasks;
using LunoNet.EnumTypes;
using LunoNet.Models;
using LunoNet.Network;
using Newtonsoft.Json;

namespace LunoNet.Controllers
{
    public class Quotes
    {
        private HttpClientWrapper _httpClient;
        private Configuration _configuration;

        public Quotes(Configuration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(Configuration));
        }

        /// <summary>
        /// Creates a new quote to buy or sell a particular amount.
        /// 
        /// You can specify either the exact amount that you want to pay or the exact amount that you want too receive.
        /// 
        /// For example, to buy exactly 0.1 Bitcoin using ZAR, you would create a quote to BUY 0.1 XBTZAR. 
        /// The returned quote includes the appropriate ZAR amount. To buy Bitcoin using exactly ZAR 100, you would create a quote to SELL 100 ZARXBT. 
        /// The returned quote specifies the Bitcoin as the counter amount that will be returned.
        /// 
        /// An error is returned if your account is not verified for the currency pair, or if your account would have insufficient balance to ever exercise the quote.
        /// </summary>
        /// <returns>The quote.</returns>
        /// <param name="pair">Pair.</param>
        public async Task<ApiResponse<Quote>> CreateQuote(QuoteType quoteType, double amount, string pair)
        {
            var postData = new QuotePostData
            {
                Type = nameof(quoteType),
                Amount = amount.ToString(),
                Pair = pair
            };

            return await HttpClient.PostAsync<Quote>("quotes", JsonConvert.SerializeObject(postData));
        }

        /// <summary>
        /// Get the latest status of a quote.
        /// </summary>
        /// <returns>The quote.</returns>
        /// <param name="quoteId">The quote id.</param>
        public async Task<ApiResponse<Quote>> GetQuote(string quoteId)
        {
            var url = $"quotes/{quoteId}";

            return await HttpClient.GetAsync<Quote>(url);
        }

        /// <summary>
        /// Exercises the quote.
        /// </summary>
        /// <returns>The quote.</returns>
        /// <param name="quoteId">Quote identifier.</param>
        public async Task<ApiResponse<Quote>> ExerciseQuote(string quoteId)
        {
            var url = $"qoutes/{quoteId}";

            return await HttpClient.GetAsync<Quote>(url);
        }

        /// <summary>
        /// Discard a quote. 
        /// Once a quote has been discarded, it cannot be exercised even if it has not expired yet.
        /// </summary>
        /// <returns>The quote.</returns>
        /// <param name="quoteId">Quote identifier.</param>
        public async Task<ApiResponse<Quote>> DiscardQuote(string quoteId)
        {
            var url = $"quotes/{quoteId}";

            return await HttpClient.DeleteAsync<Quote>(url);
        }

        /// <summary>
        /// Returns an instance of the HttpClientWrapper.
        /// </summary>
        /// <value>The http client.</value>
        private HttpClientWrapper HttpClient
        {
            get
            {
                return _httpClient ?? (_httpClient = HttpClientWrapper.Create(_configuration));
            }
        }

    }
}
