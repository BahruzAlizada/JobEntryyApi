using JobEntryy.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobEntryy.Persistence.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Category> Categories { get; set; }
    }
}
