using System.Collections.Generic;
using Thrifty.Models;

namespace Thrifty.Web.Models.Transaction
{
    public class AddTransactionVM
    {
        public List<Account> Accounts { get; set; }

        public int DebitAccount { get; set; }
        public decimal DebitAmount { get; set; } 

        public int CreditAccount { get; set; }
        public decimal CreditAmount { get; set; }
    }
}
