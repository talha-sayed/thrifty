using System.Threading.Tasks;
using Thrifty.Abstractions.Repositories;
using Thrifty.Abstractions.Services;

namespace Thrifty.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        
        public async Task<int> Create(string name, string key)
        {
            return await _accountRepository.Create(name, key);
        }
    }
}
