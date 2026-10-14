using System.ComponentModel.DataAnnotations;

namespace CargoTrackingg.ViewModels
{
    public class CustomerProfileViewModel
    {
        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }
    }
}
