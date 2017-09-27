using System.Collections.Generic;

namespace Thrifty.Models
{
    public class Transaction
    {
        public Transaction()
            : this(string.Empty)
        {
        }

        public Transaction(string description)
        {
            Description = description;
            Legs = new List<TransactionLeg>();
        }

        public string Description { get; set; }

        public List<TransactionLeg> Legs { get; set; }
    }
}
