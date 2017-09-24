using System.Collections.Generic;

namespace Thrifty.Models
{
    public class Transaction
    {
        public Transaction()
        {
            Legs = new List<TransactionLeg>();
        }

        public string Description { get; set; }

        public IEnumerable<TransactionLeg> Legs { get; set; }
    }
}
