using Microsoft.EntityFrameworkCore;
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

        public DbSet<TransactionLegEntity> TransactionLeg { get; set; }

        public DbSet<AccountEntity> Account { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
