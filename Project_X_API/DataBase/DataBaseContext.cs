using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Project_X_API.DataBase.Configuration;
using Project_X_API.DataBase.Tables;

namespace Project_X_API.DataBase
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}