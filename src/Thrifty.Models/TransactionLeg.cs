namespace Thrifty.Models
{
    public class TransactionLeg
    {
        public static TransactionLeg CreateDebit(decimal amount)
        {
            return new TransactionLeg
            {
                IsDebit = true,
                Amount = amount
            };
        }

        public static TransactionLeg CreateCredit(decimal amount)
        {
            return new TransactionLeg
            {
                IsDebit = false,
                Amount = amount
            };
        }

        public bool IsDebit { get; set; }

        public decimal Amount { get; set; }
    }
}
