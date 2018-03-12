namespace LunoNet.Models
{
    public class Transaction
    {
        public long Row_Index { get; set; }
        public long Timestamp { get; set; }
        public double Balance { get; set; }
        public double Available { get; set; }
        public string Account_Id { get; set; }
        public double Balance_Delta { get; set; }
        public double Available_Delta { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public object Details { get; set; }
    }
}
