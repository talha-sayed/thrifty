using System.Threading.Tasks;
using Thrifty.Models;

namespace Thrifty.Abstractions.Repositories
{
    public interface IAccountRepository
    {
        Task<int> Create(string name, string key);
    }
}
