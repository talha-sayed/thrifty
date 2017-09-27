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

        public async Task Create(Transaction transaction)
        {
            _context.Transaction.Add(new TransactionEntity
            {
                Description = transaction.Description,
                Legs = transaction.Legs.Select(x =>
                {
                    return new TransactionLegEntity { Amount = x.Amount };
                }).ToList()
            });

            await _context.SaveChangesAsync();
        }
    }
}
