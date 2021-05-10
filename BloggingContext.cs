using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LibraryConsole
{
    public class BloggingContext : DbContext
    {
        public DbSet<Models.Movie> Movies { get; set; }
        public DbSet<Models.User> Users { get; set; }
        

        
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            optionsBuilder.UseSqlServer("");
        }
    }
    
}