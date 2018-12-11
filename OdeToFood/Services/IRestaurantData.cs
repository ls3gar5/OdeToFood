﻿using OdeToFood.Models;
using System.Collections.Generic;

namespace OdeToFood.Services
{
    public interface IRestaurantData
    {

        IEnumerable<Restaurant> GetAll();
        Restaurant Get(int id);
        Restaurant Add(Restaurant Restaurant);
        Restaurant Update(Restaurant Restaurant);
    }
}
