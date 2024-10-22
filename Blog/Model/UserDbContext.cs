using Microsoft.EntityFrameworkCore;

namespace Blog.Models
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> NewUser { get; set; } = null!;
        public UserDbContext() { }

        public UserDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string conn = "server=localhost; database=Blog; user=root; password=";

                optionsBuilder.UseMySQL(conn);
            }
        }


    }
}