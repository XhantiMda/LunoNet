namespace LunoNet.Models
{
    public class Ticker
    {
        public long Timestamp { get; set; }
        public string Bid { get; set; }
        public string Ask { get; set; }
        public string LastTrade { get; set; }
        public string Rolling24_HourVolume { get; set; }
        public string Pair { get; set; }
    }
}
