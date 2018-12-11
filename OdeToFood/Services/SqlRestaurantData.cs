using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Data;
using OdeToFood.Models;

namespace OdeToFood.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdoToFoodDbContext _context;

        public SqlRestaurantData(OdoToFoodDbContext context)
        {
            _context = context;
        }


        public Restaurant Add(Restaurant resto)
        {
            _context.Restaurants.Add(resto);
            _context.SaveChanges();
            return resto;
        }

        public Restaurant Get(int id)
        {
            return _context.Restaurants.FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants.AsEnumerable();
        }

        public Restaurant Update(Restaurant Restaurant)
        {
            _context.Attach(Restaurant).State = EntityState.Modified;
            _context.SaveChanges();

            return Restaurant;

        }
    }
}
