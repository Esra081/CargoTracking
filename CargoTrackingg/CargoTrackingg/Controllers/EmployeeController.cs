using CargoTrackingg.Data;
using CargoTrackingg.Models;
using CargoTrackingg.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CargoTrackingg.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly CargoDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public EmployeeController(CargoDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Employee/Index (Dashboard)
        [HttpGet]
        public IActionResult Index()
        {
            return View(); // Views/Employee/Index.cshtml
        }


        // GET: Employee/Profile
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToAction("Login", "Account");

            var profileViewModel = new ProfileViewModel
            {
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role,
                PhoneNumber = user.PhoneNumber
            };

            return View(profileViewModel);
        }

        // POST: Employee/Profile
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Profile(ProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Please fill all the required fields correctly.";
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToAction("Login", "Account");

            // Bilgileri güncelle
            user.FullName = model.FullName;
            user.PhoneNumber = model.PhoneNumber;
            _context.Update(user);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Profile updated successfully.";
            return RedirectToAction("Profile");
        }

        // GET: Employee/CargoManagement
        [HttpGet]
        public IActionResult CargoManagement()
        {
            return View(); // Views/Employee/CargoManagement.cshtml
        }

        // Listing Orders
        [HttpGet]
        public IActionResult Orders(string period)
        {
            var shipments = _context.Shipments.Include(s => s.Branch).AsQueryable();

            var today = DateTime.Today;

            if (period == "daily")
            {
                shipments = shipments.Where(s => s.EstimatedDeliveryDate.Date == today);
            }
            else if (period == "weekly")
            {
                var startOfWeek = today.AddDays(-(int)today.DayOfWeek); // Pazara göre başlar
                var endOfWeek = startOfWeek.AddDays(7);

                shipments = shipments.Where(s => s.EstimatedDeliveryDate >= startOfWeek && s.EstimatedDeliveryDate < endOfWeek);
            }
            else if (period == "monthly")
            {
                var startOfMonth = new DateTime(today.Year, today.Month, 1);
                var endOfMonth = startOfMonth.AddMonths(1);

                shipments = shipments.Where(s => s.EstimatedDeliveryDate >= startOfMonth && s.EstimatedDeliveryDate < endOfMonth);
            }
            else if (period == "yearly")
            {
                var startOfYear = new DateTime(today.Year, 1, 1);
                var endOfYear = startOfYear.AddYears(1);

                shipments = shipments.Where(s => s.EstimatedDeliveryDate >= startOfYear && s.EstimatedDeliveryDate < endOfYear);
            }



            var orders = shipments.Select(s => new OrderViewModel
            {
                TrackingNumber = s.TrackingNumber,
                Sender = s.SenderName,
                Receiver = s.ReceiverName,
                Date = s.EstimatedDeliveryDate,
                Status = s.Status,
                BranchName = s.Branch != null ? s.Branch.Name : "N/A"
            }).ToList();

            return View(orders);
        }


    }
}