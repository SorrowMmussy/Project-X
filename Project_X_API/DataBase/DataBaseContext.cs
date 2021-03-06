using Microsoft.EntityFrameworkCore;
using Project_X_API.DataBase.Configuration;
using Project_X_API.DataBase.Tables;

namespace Project_X_API.DataBase
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        public DbSet<Role> Roles { get; set; }

        public DbSet<ExplosiveData> ExplosiveData { get; set; }

        public DbSet<User> UserInfo { get; set; }

        public DbSet<TokenValidation> TokenValidations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UsersConfiguration());
            modelBuilder.ApplyConfiguration(new TokenValidationConfiguration());
            modelBuilder.ApplyConfiguration(new ExplosiveDataConfiguration());
        }
    }
}