using System.Collections.Generic;

namespace Thrifty.Models
{
    public class Transaction
    {
        public IEnumerable<TransactionLeg> Legs { get; set; }
    }
}
