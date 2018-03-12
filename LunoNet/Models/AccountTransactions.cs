namespace LunoNet.Models
{
    public class AccountTransactions
    {
        public string Id { get; set; }
        public bool Is_Default { get; set; }
        public Transaction[] Transactions {get; set;}
        public object Capabilities { get; set; }
    }
}
