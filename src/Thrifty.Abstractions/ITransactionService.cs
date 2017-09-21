using Thrifty.Models;

namespace Thrifty.Abstractions
{
    public interface ITransactionService
    {
        bool ValidateTransaction(Transaction transaction);
    }
}
