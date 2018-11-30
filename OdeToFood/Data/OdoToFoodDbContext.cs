using Microsoft.EntityFrameworkCore;
using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
