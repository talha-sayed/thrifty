using System.Threading.Tasks;
using Thrifty.Models;

namespace Thrifty.Abstractions
{
    public interface ITransactionRepository
    {
        Task Create(Transaction transaction);
    }
}
