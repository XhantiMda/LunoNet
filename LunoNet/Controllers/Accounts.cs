using System;
using LunoNet.Network;
using LunoNet.Models;
using System.Threading.Tasks;

namespace LunoNet.Controllers
{
    public class Accounts
    {
        private HttpClientWrapper _httpClient;
        private Configuration _configuration;

        public Accounts(Configuration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(Configuration));
        }

        /// <summary>
        /// Returns a list of all accounts and their respective balances.
        /// </summary>
        /// <returns>The balance.</returns>
        public async Task<ApiResponse<UserBalance>> GetBalance()
        {
            return await HttpClient.GetAsync<UserBalance>("balance");    
        }

        /// <summary>
        /// Returns a list of transaction entries from an account.
        /// 
        /// Transaction entry rows are numbered sequentially starting from 1, where 1 is the oldest entry. 
        /// The range of rows to return are specified with the min_row (inclusive) and max_row (exclusive) parameters. 
        /// At most 1000 rows can be requested per call.
        /// 
        /// If min_row or max_row is non-positive, the range wraps around the most recent row. 
        /// For example, to fetch the 100 most recent rows, use min_row=-100 and max_row=0.
        /// </summary>
        /// <returns>The transactions.</returns>
        /// <param name="accountId">Account identifier.</param>
        /// <param name="minRows">Minimum rows.</param>
        /// <param name="maxRows">Max rows.</param>
        public async Task<ApiResponse<AccountTransactions>> GetTransactions(string accountId, int minRows = 1, int maxRows = 100)
        {
            var url = $"accounts/{accountId}/transactions?min_row={minRows}&max_row={maxRows}";

            return await HttpClient.GetAsync<AccountTransactions>(url);
        }

        /// <summary>
        /// Return a list of all pending transactions related to the account.
        /// 
        /// Unlike account entries, pending transactions are not numbered, and may be reordered, deleted or updated at any time.
        /// </summary>
        /// <returns>The pending transactions.</returns>
        /// <param name="accountId">Account identifier.</param>
        public async Task<ApiResponse<PendingTransactions>> GetPendingTransactions(string accountId)
        {
            var url = $"accounts/{accountId}/pending";

            return await HttpClient.GetAsync<PendingTransactions>(url);
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
