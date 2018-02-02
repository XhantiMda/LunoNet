
namespace LunoNet.Models
{
    public class Trade
    {
        public string Volume { get; set; }
        public long Timestamp { get; set; }
        public string Price { get; set; }
        public bool IsBuy { get; set; }
    }
}
