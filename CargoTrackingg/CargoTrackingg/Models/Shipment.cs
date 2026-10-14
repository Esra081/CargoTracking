using System.ComponentModel.DataAnnotations;
namespace CargoTrackingg.Models
{
    public class Shipment
    {
        public int Id { get; set; }

        [Required]
        public string SenderName { get; set; }

        [Required]
        public string ReceiverName { get; set; }

        [Required]
        public string FromAddress { get; set; }

        [Required]
        public string ToAddress { get; set; }

        [Required]
        public DateTime EstimatedDeliveryDate { get; set; }

        [Required]
        public double Weight { get; set; }

        public string? Status { get; set; }
        public string? TrackingNumber { get; set; }

        public bool IsApproved { get; set; }
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Package Description")]
        public string? PackageDescription { get; set; }
        public int? BranchId { get; set; }
        public Branch? Branch { get; set; }


        public string? AppUserId { get; set; }  // FK nullable olabilir
        public virtual AppUser? AppUser { get; set; }  // navigation, nullable

        public virtual List<ShipmentStatusHistory> StatusHistories { get; set; } = new();


    }


}
