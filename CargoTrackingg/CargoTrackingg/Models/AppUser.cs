using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace CargoTrackingg.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(20)]
        public string Role { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;

        public string? Address { get; set; }
        public Customer Customer { get; set; } // optional
        public Employee Employee { get; set; } // optional
    }
}
