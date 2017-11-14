using System.Collections.Generic;
using System.Threading.Tasks;
using Thrifty.Abstractions.Repositories;
using Thrifty.Abstractions.Services;
using Thrifty.Models;

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

        public async Task<List<Account>> GetAllAccounts()
        {
            return await _accountRepository.GetAllAccounts();
        }

        public Task Delete(string key)
        {
            return _accountRepository.Delete(key);
        }

        public Task Get(string key)
        {
            return _accountRepository.Get(key);
        }
    }
}
