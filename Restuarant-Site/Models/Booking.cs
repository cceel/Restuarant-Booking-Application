using System.ComponentModel.DataAnnotations;

namespace Restuarant_Site.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "location is required")]
        [MaxLength(64, ErrorMessage = "Length of location cannot be greater than 64 characters")]
        [MinLength(2, ErrorMessage = "Length of location cannot be less than 2 characters")]
        public string? Location { get; set; }

        public string? BookingDateTime { get; set; }

        [Required(ErrorMessage = "firstName is required")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "lastName is required")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "phoneNumber is required")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "partySize is required")]
        public string? PartySize { get; set; }

        [Required(ErrorMessage = "notes is required")]
        public string? Notes { get; set; }

        [Required(ErrorMessage = "info is required")]
        public string? Info { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public string? Status { get; set; }

    }
}
