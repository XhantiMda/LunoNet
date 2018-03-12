namespace LunoNet.Models
{
    public class PendingTransactions
    {
        public string Id { get; set; }

        public Transaction[] Pending { get; set; }
    }
}
