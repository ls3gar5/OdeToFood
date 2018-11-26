using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Models
{

    /// <summary>
    /// Models are components that will hold information
    /// </summary>
    public class Restaurant
    {
        public int Id { get; set; }
        [Display(Name ="Restaurant Name")]
        [Required, MaxLength(80,ErrorMessage ="El nombre menor a 80")]
        public string Name { get; set; }
        public CouisineType Couisine { get; set; }
    }
}
