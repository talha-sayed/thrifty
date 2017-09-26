using Microsoft.EntityFrameworkCore;
using Thrifty.Abstractions;
using Thrifty.Data.Entities;

namespace Thrifty.Data
{
    public class ThriftyDbContext : DbContext
    {
        public ThriftyDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<TransactionEntity> Transaction { get; set; }

    }
}
