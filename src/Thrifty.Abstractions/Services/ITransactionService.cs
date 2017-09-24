using System.Threading.Tasks;
using Thrifty.Models;

namespace Thrifty.Abstractions
{
    public interface ITransactionService
    {
        bool ValidateTransaction(Transaction transaction);

        Task CreateSampleTransaction(Transaction transaction);
    }
}
