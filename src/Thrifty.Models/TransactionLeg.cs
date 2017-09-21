namespace Thrifty.Models
{
    public class TransactionLeg
    {
        public bool IsDebit { get; set; }

        public decimal Amount { get; set; }
    }
}
