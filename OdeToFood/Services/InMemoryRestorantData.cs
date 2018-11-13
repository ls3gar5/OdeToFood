using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Services
{
    public class InMemoryRestorantData : IRestorantData
    {
        List<Restaurant> _restorats;

        public InMemoryRestorantData()
        {
            _restorats = new List<Restaurant>()
            {
                new Restaurant(){Id =1, Name="Scott's Pizza"},
                new Restaurant(){Id =2 , Name="Tersigels"},
                new Restaurant(){Id =3 , Name="King's Beer"}
            };
        }

        public Restaurant Get(int id)
        {
            return _restorats.FirstOrDefault(f=>f.Id==id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restorats;
        }
    }
}
