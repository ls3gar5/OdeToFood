using Microsoft.EntityFrameworkCore;
using OdeToFood.Models;

namespace OdeToFood.Data
{
    public class OdoToFoodDbContext : DbContext
    {
        public OdoToFoodDbContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
