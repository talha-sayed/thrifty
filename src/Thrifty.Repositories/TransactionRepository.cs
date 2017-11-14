using System;
using System.Linq;
using System.Threading.Tasks;
using Thrifty.Abstractions;
using Thrifty.Data;
using Thrifty.Data.Entities;
using Thrifty.Models;

namespace Thrifty.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private ThriftyDbContext _context;

        public TransactionRepository(ThriftyDbContext context)
        {
            _context = context;
        }

        public Task Create(Transaction transaction)
        {
            _context.Transaction.Add(new TransactionEntity
            {
                Description = transaction.Description,
                Legs = transaction.Legs.Select(x => new TransactionLegEntity { Amount = x.Amount }).ToList()
            });

            return _context.SaveChangesAsync();
        }

        public Task Create(string creditAccount, string debitAccount, decimal amount, string description)
        {
            _context.Transaction.Add(new TransactionEntity
            {
                Description = description,
                Legs =
                {
                    new TransactionLegEntity {
                        Amount = amount,
                        AccountKey = creditAccount,
                        Timestamp = DateTime.Now
                        
                    },
                    new TransactionLegEntity
                    {
                        Amount = amount,
                        AccountKey = debitAccount,
                        Timestamp = DateTime.Now
                    }
                }
            });

            return  _context.SaveChangesAsync();
        }
    }
}
