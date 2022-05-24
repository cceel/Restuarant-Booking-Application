using System.ComponentModel.DataAnnotations;

namespace Restuarant_Site.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Item is required")]
        public string? Item { get; set; }

        [Required(ErrorMessage = "Type is required")]
        public string? Type { get; set; }

        [Required(ErrorMessage = "Calories is required")]
        public string? Calories { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public string? Price { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public string? Status { get; set; }

    }
}
