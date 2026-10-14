using System;
using System.ComponentModel.DataAnnotations;

namespace CargoTrackingg.ViewModels
{
    public class ProfileViewModel
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

        [Required]
        [MaxLength(20)]
        public string Role { get; set; }
    }
}
