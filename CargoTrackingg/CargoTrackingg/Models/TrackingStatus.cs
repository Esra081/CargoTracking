using System;
using System.ComponentModel.DataAnnotations;

namespace CargoTrackingg.Models
{
    public class TrackingStatus
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tracking Number")]
        public string TrackingNumber { get; set; }

        [Required]
        [Display(Name = "Status")]
        public string StatusDescription { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Date Time")]
        public DateTime StatusDate { get; set; } = DateTime.Now;
    }
}
