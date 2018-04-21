namespace LunoNet.Models
{
    public class OrderPostData
    {
        /// <summary>
        ///  The currency pair to trade e.g. XBTZAR or ETHXBT
        /// </summary>
        public string Pair { get; set; }

        /// <summary>
        /// "BID" for a bid (buy) limit order or "ASK" for an ask (sell) limit order.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Amount of Bitcoin or Ethereum to buy or sell as a decimal string in units of BTC e.g. "1.423".
        /// </summary>
        public string Volume { get; set; }

        /// <summary>
        /// Limit price as a decimal string in units of ZAR/BTC e.g. "1200".
        /// </summary>
        /// <value>The price.</value>
        public string Price { get; set; }

        /// <summary>
        /// The base currency account to use in the trade.
        /// </summary>
        public string Base_Account_Id { get; set; } 

        /// <summary>
        /// The counter currency account to use in the trade.
        /// </summary>
        public string Counter_Account_Id { get; set; }
    }
}
