using Microsoft.EntityFrameworkCore;

namespace Case2.NAAM.APPLICATIENAAM.Infrastructure.DatabaseContexts
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<Entity> Entities { get; set; }

        public DatabaseContext()
        {
            this.Database.EnsureCreated();
        }
        public DatabaseContext(DbContextOptions options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=DATABASENAME;Trusted_Connection=True;");
            }
        }
    }
}