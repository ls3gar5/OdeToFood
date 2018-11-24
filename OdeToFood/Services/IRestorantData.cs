using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Services
{
    public interface IRestorantData
    {

        IEnumerable<Restaurant> GetAll();
        Restaurant Get(int id);
        int GetLastId();
    }
}
