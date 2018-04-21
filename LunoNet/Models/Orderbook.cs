namespace LunoNet.Models
{
    public class Orderbook
    {
        public long Timestamp { get; set; }
        public MarketOrder[] Bids { get; set; }
        public MarketOrder[] Asks { get; set; }
    }
}
