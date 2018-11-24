using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Models
{

    /// <summary>
    /// Models are components that will hold information
    /// </summary>
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CouisineType Couisine { get; set; }
    }
}
