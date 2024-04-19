using ASP_SPU221_HMW.Data.Entitys;
using Microsoft.EntityFrameworkCore;

namespace ASP_SPU221_HMW.Data.Context
{
    public class DataContext:DbContext
    {
        public DbSet<User> Users {  get; set; }
        public DataContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
