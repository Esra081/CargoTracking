using Microsoft.AspNetCore.Mvc;

namespace CargoTrackingg.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult WhyUs()
        {
            return View();
        }

        public IActionResult Testimonials()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        // For track number
        [HttpPost]
        public IActionResult Track(string trackingNumber)
        {
            if (string.IsNullOrWhiteSpace(trackingNumber))
            {
                TempData["ErrorMessage"] = "Please enter a tracking number.";
                return RedirectToAction("Index");
            }

            // ShipmentController.Details metoduna yönlendirme yap
            return RedirectToAction("Details", "Shipment", new { trackingNumber = trackingNumber });
        }

    }


}
