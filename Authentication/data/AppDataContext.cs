using Authentication.data.mapping;
using Authentication.models;
using Microsoft.EntityFrameworkCore;


namespace Authentication.data
{
    public class AppDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Links> Links { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=AuthApi;User ID=sa;Password=1q2w3e4r@#$");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UserMapping());

        }
    }
}