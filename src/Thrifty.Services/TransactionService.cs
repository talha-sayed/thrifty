using System.Linq;
using Thrifty.Abstractions;
using Thrifty.Models;

namespace Thrifty.Services
{
    public class TransactionService : ITransactionService
    {
        public bool ValidateTransaction(Transaction transaction)
        {
            var totalDebit = transaction.Legs.Where(tran => tran.IsDebit == true).Sum(x => x.Amount);
            var totalCredit = transaction.Legs.Where(tran => tran.IsDebit == false).Sum(x => x.Amount);

            return totalDebit == totalCredit;
        }
    }
}
