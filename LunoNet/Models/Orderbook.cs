namespace LunoNet.Models
{
    public class Orderbook
    {
        public long Timestamp { get; set; }
        public Order[] Bids { get; set; }
        public Order[] Asks { get; set; }
    }
}
