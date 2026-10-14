using System.ComponentModel.DataAnnotations;

namespace CargoTrackingg.Models
{
    public class Branch
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Branch Name")]
        public string Name { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Adress")]
        public string Address { get; set; }
    }
}
