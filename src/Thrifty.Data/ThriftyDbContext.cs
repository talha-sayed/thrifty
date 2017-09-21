using Microsoft.EntityFrameworkCore;
using Thrifty.Abstractions;

namespace Thrifty.Data
{
    public class ThriftyDbContext : DbContext, IApplicationDbContext
    {
        public ThriftyDbContext()
            :base()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
