using BookMarketplace.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookMarketplace.API.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}
