using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CargoTrackingg.Models
{
    public class Customer
    {
        public string AppUserId { get; set; }  // Foreign key

        [ForeignKey("AppUserId")]
        public AppUser AppUser { get; set; }   // Navigation property

        public int Id { get; set; }

        [Required]
        [Display(Name = "Name Surname")]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Address")]
        public string? Address { get; set; }
    }
}
