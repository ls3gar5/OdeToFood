﻿using OdeToFood.Models;
using System.ComponentModel.DataAnnotations;

namespace OdeToFood.ViewModels
{
    public class RestaurantEditModel
    {
        [Display(Name = "Restaurant Name")]
        [Required, MaxLength(80, ErrorMessage = "El nombre menor a 80")]
        public string Name { get; set; }
        public CouisineType Couisine { get; set; }
    }
}
