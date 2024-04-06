using Microsoft.EntityFrameworkCore;

namespace BookMarketplace.API.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
