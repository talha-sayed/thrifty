using System.Collections.Generic;
using System.Threading.Tasks;
using Thrifty.Models;

namespace Thrifty.Abstractions
{
    public interface ITransactionRepository
    {
        Task Create(Transaction transaction);
        Task Create(string creditAccount, string debitAccount, decimal amount, string description);
        Task<List<Transaction>> Get();
    }
}
