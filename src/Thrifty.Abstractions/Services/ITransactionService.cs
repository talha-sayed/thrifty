using System.Threading.Tasks;
using Thrifty.Models;

namespace Thrifty.Abstractions
{
    public interface ITransactionService
    {
        Task CreateTransaction(Transaction transaction);
        Task CreateTransaction(string creditAccount, string debitAccount, decimal amount, string description);
    }
}
