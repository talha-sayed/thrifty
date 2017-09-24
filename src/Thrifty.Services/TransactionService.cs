using System;
using System.Linq;
using System.Threading.Tasks;
using Thrifty.Abstractions;
using Thrifty.Models;

namespace Thrifty.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public bool ValidateTransaction(Transaction transaction)
        {
            var totalDebit = transaction.Legs.Where(tran => tran.IsDebit == true).Sum(x => x.Amount);
            var totalCredit = transaction.Legs.Where(tran => tran.IsDebit == false).Sum(x => x.Amount);

            return totalDebit == totalCredit;
        }

        public async Task CreateSampleTransaction(Transaction transaction)
        {
            if (!ValidateTransaction(transaction))
            {
                throw new Exception("Invalid transaction");
            }

            await _transactionRepository.Create(transaction);
        }
    }
}
