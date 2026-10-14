using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CargoTrackingg.Models;
using CargoTrackingg.ViewModels;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CargoTrackingg.Data;

namespace CargoTrackingg.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly CargoDbContext _context;


        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, CargoDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        // GET: Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Kullanıcıyı e-posta ile bul
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                // Şifre kontrolü
                var passwordCheck = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                if (passwordCheck.Succeeded)
                {
                    // Giriş başarılı
                    TempData["SuccessMessage"] = "Giriş başarılı!";

                    // Role bilgisini Session'a ekle
                    HttpContext.Session.SetString("Role", user.Role);

                    // Rol bazlı yönlendirme
                    if (user.Role == "Personnel")
                        return RedirectToAction("Orders", "Employee");

                    if (user.Role == "Customer")
                        return RedirectToAction("CargoTracking", "Customer");

                    // Rol eşleşmiyorsa ana sayfaya yönlendir
                    return RedirectToAction("Index", "Home");
                }
            }

            TempData["ErrorMessage"] = "Geçersiz e-posta veya şifre.";
            return View(model);
        }

        // GET: Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (string.IsNullOrWhiteSpace(model.Role) ||
                (model.Role != "Customer" && model.Role != "Personnel"))
            {
                TempData["ErrorMessage"] = "Please select a valid role (Customer or Personnel).";
                return RedirectToAction("Register");
            }

            if (model.Role == "Personnel")
            {
                if (!User.Identity.IsAuthenticated)
                {
                    TempData["ErrorMessage"] = "You must be logged in to register a personnel user.";
                    return RedirectToAction("Register");
                }

                var currentUserRole = HttpContext.Session.GetString("Role");
                if (currentUserRole != "Personnel")
                {
                    TempData["ErrorMessage"] = "Access denied! Only personnel users can register new personnel.";
                    return RedirectToAction("Register");
                }
            }

            var user = new AppUser
            {
                UserName = model.Email,
                Email = model.Email,
                FullName = model.FullName,
                Role = model.Role,
                DateCreated = DateTime.Now
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // Otomatik giriş sadece yeni müşteri kaydıysa yapılır
                if (!User.Identity.IsAuthenticated)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    HttpContext.Session.SetString("Role", user.Role);
                }

                //User tablosu dışında customer ve personnel tablosuna atma
                if (model.Role == "Personnel")
                {
                    var employee = new Employee
                    {
                        FullName = model.FullName,
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber,
                        Position = model.Position,
                        AppUserId = user.Id
                    };
                    _context.Employees.Add(employee);
                }
                else if (model.Role == "Customer")
                {
                    var customer = new Customer
                    {
                        FullName = model.FullName,
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber,
                        Address = model.Address,
                        AppUserId = user.Id
                    };
                    _context.Customers.Add(customer);
                }

                await _context.SaveChangesAsync(); // EF ile veritabanına kaydet

                TempData["SuccessMessage"] = "Registration successful!";
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }


        // POST: Account/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            HttpContext.Session.Clear(); // opsiyonel, session'ları da temizler
            return RedirectToAction("Index", "Home");
        }
    }
}
