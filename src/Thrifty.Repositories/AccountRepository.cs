using System;
using System.Threading.Tasks;
using Thrifty.Abstractions.Repositories;
using Thrifty.Data;
using Thrifty.Data.Entities;

namespace Thrifty.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ThriftyDbContext _context;

        public AccountRepository(ThriftyDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(string name, string key)
        {
            var account = new AccountEntity()
            {
                Name = name,
                Key = key,
                CreatedOn = DateTime.Now
            };

            _context.Account.Add(account);

            await _context.SaveChangesAsync();

            return account.Id;
        }
    }
}
