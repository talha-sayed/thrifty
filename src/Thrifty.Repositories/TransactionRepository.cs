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
                Description = transaction.Description
            });

            await _context.SaveChangesAsync();
        }
    }
}
