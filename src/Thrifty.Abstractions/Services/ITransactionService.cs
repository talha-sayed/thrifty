using System.Threading.Tasks;
using Thrifty.Models;

namespace Thrifty.Abstractions
{
    public interface ITransactionService
    {
        Task CreateTransaction(Transaction transaction);
    }
}
