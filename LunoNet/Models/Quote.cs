namespace LunoNet.Models
{
    public class Quote
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Pair { get; set; }
        public string Base_Amount { get; set; }
        public string Counter_Amount { get; set; }
        public long Created_At { get; set; }
        public long Expires_At { get; set; }
        public bool Discarded { get; set; }
        public bool Exercised { get; set; }
    }
}
