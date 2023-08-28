using Microsoft.EntityFrameworkCore;
using SpeedersAPI.Entities;

namespace SpeedersAPI.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "UsersDb");
        }


        public DbSet<UserEntity> Users { get; set; }

    }
}
