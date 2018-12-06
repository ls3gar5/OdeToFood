using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Models;
using OdeToFood.Services;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        public int idResto { get; set; }

        [BindProperty]
        public Restaurant resto { get; private set; }

        private readonly IRestaurantData _restaurantData;

        public EditModel(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public IActionResult OnGet(int id)
        {
            resto = _restaurantData.Get(id);
            if (resto == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return Page();

        }

        public IActionResult OnPost(Restaurant restaurant)
        {

        }
    }
}