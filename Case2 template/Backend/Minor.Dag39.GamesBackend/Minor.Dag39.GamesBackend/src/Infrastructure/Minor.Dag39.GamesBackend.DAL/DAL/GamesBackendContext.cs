using Microsoft.EntityFrameworkCore;
using Minor.Dag39.GamesBackend.Entities;

namespace Minor.Dag39.GamesBackend.Infrastructure.DAL
{
    public class GamesBackendContext : DbContext
    {
        public virtual DbSet<Room> Games { get; set; }
        public virtual DbSet<Player> Players { get; set; }

        public GamesBackendContext()
        {
            Database.Migrate();
        }

        public GamesBackendContext(DbContextOptions options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().Property(r => r.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Player>().Property(p => p.Id).ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            if (!optionsBuilder.IsConfigured) 
            {
                optionsBuilder.UseSqlServer(@"Server=db;Database=GameServer;UserID=sa,Password=admin");
            }
        }
    }
}