using Microsoft.EntityFrameworkCore;

namespace DB
{
    public class ServiceSSRContext : DbContext
    {
        public ServiceSSRContext(DbContextOptions<ServiceSSRContext> options) : base(options)
        {

        }

        public DbSet<User> users { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Stat> Stats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercise>().ToTable("Exercise");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Stat>().ToTable("Stat");
        }
    }
}