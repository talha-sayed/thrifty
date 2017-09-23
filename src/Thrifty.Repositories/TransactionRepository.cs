using System.Threading.Tasks;
using Thrifty.Abstractions;
using Thrifty.Data;
using Thrifty.Data.Entities;

namespace Thrifty.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private ThriftyDbContext _context;

        public TransactionRepository(ThriftyDbContext context)
        {
            _context = context;
        }

        public async Task Create()
        {
            _context.Transaction.Add(new TransactionEntity
            {
                Description = "Basic expense"
            });

            await _context.SaveChangesAsync();
        }
    }
}
