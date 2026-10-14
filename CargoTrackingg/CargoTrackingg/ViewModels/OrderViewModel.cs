namespace CargoTrackingg.ViewModels
{
    public class OrderViewModel
    {
        public string TrackingNumber { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string BranchName { get; set; }
    }
}
