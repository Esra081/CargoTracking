using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace CargoTrackingg.Models
{
    public class ShipmentStatusHistory
    {
        public int Id { get; set; }

        [Required]
        public int ShipmentId { get; set; }

        [ValidateNever]
        public Shipment Shipment { get; set; }

        [Required]
        public string Status { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int? BranchId { get; set; }
        public Branch? Branch { get; set; }


        [NotMapped]
        public string? FromAddress { get; set; }

        [NotMapped]
        public string? ToAddress { get; set; }

        public string? AppUserId { get; set; }

        [ForeignKey("AppUserId")]
        public AppUser? AppUser { get; set; }

    }
}

