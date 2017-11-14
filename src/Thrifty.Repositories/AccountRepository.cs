using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Thrifty.Abstractions.Repositories;
using Thrifty.Data;
using Thrifty.Data.Entities;
using Thrifty.Models;

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

        public async Task<List<Account>> GetAllAccounts()
        {
            return await _context.Account.Select(x=> new Account()
            {
                Id = x.Id,
                Key = x.Key,
                Name = x.Name,
                CreatedOn = x.CreatedOn,
                UpdatedOn = x.UpdatedOn
            }).ToListAsync();
        }

        public async Task Delete(string key)
        {
            var accounts = await _context.Account.Where(x => x.Key == key).ToListAsync();
            _context.RemoveRange(accounts);
            await _context.SaveChangesAsync();
        }

        public Task Get(string key)
        {
            return _context.Account.SingleAsync(x => x.Key == key);
        }
    }
}
