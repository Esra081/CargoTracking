using CargoTrackingg.Data;
using CargoTrackingg.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

public class ShipmentController : Controller
{
    private readonly CargoDbContext _context;
    private readonly UserManager<AppUser> _userManager;

    public ShipmentController(CargoDbContext context, UserManager<AppUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    // GET: /Shipment/Create (Customer)
    public IActionResult Create()
    {
        return View();
    }

    // POST: /Shipment/Create (Customer)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Shipment shipment)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToAction("Login", "Account");

            shipment.CreatedAt = DateTime.Now;
            shipment.IsApproved = false;
            shipment.TrackingNumber = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
            shipment.Status = "Pending";
            shipment.AppUserId = user.Id; // 👈 EKLENEN KRİTİK KISIM

            _context.Shipments.Add(shipment);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "Shipment", new { id = shipment.Id });

        }


        return View(shipment);
    }

    // GET: /Shipment/Pending (Staff)
    public IActionResult Pending()
    {
        var pendingShipments = _context.Shipments
            .Where(s => !s.IsApproved)
            .OrderByDescending(s => s.CreatedAt)
            .ToList();

        return View(pendingShipments);
    }

    // POST: /Shipment/Approve (Staff)
    [HttpPost]
    public IActionResult Approve(int id, string selectedStatus, DateTime estimatedDeliveryDate)
    {
        var shipment = _context.Shipments.Find(id);
        if (shipment == null) return NotFound();

        shipment.IsApproved = true;
        shipment.Status = selectedStatus;
        shipment.EstimatedDeliveryDate = estimatedDeliveryDate;

        _context.SaveChanges();

        return RedirectToAction("Pending");
    }

    // POST: /Shipment/Reject (Staff)
    [HttpPost]
    public IActionResult Reject(int id)
    {
        var shipment = _context.Shipments.Find(id);
        if (shipment == null)
            return NotFound();

        _context.Shipments.Remove(shipment);
        _context.SaveChanges();

        return RedirectToAction("Pending");
    }

    // ID ile erişim
    [HttpGet("Shipment/Details/{id:int}")]
    public IActionResult Details(int id)
    {
        var shipment = _context.Shipments.Find(id);
        if (shipment == null) return NotFound();

        return View(shipment);
    }

    // Status Güncelleme View'ini Göster (GET)
    [HttpGet]
    public IActionResult UpdateStatus(int shipmentId)
    {
        var shipment = _context.Shipments.Find(shipmentId);
        if (shipment == null)
            return NotFound();

        ViewBag.Branches = new SelectList(_context.Branches, "Id", "Name");

        var model = new ShipmentStatusHistory
        {
            ShipmentId = shipment.Id,
            FromAddress = shipment.FromAddress,
            ToAddress = shipment.ToAddress
        };

        return View("~/Views/Employee/UpdateStatus.cshtml", model);
    }

    // Status Güncelleme POST işlemi
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateStatus(ShipmentStatusHistory model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Branches = new SelectList(_context.Branches, "Id", "Name");
            return View("~/Views/Employee/UpdateStatus.cshtml", model);
        }

        var shipment = _context.Shipments.FirstOrDefault(s => s.Id == model.ShipmentId);
        if (shipment == null)
        {
            ViewBag.Error = "Shipment not found!";
            ViewBag.Branches = new SelectList(_context.Branches, "Id", "Name");
            return View("~/Views/Employee/UpdateStatus.cshtml", model);
        }

        var user = await _userManager.GetUserAsync(User); 
        if (user == null)
        {
            return RedirectToAction("Login", "Account");
        }

        shipment.Status = model.Status;
        model.UpdatedAt = DateTime.Now;
        model.AppUserId = user.Id; 

        _context.ShipmentStatusHistories.Add(model);
        _context.SaveChanges();

        return RedirectToAction("Details", "Shipment", new { id = shipment.Id });
    }


    [HttpGet]
    public IActionResult UpdateStatusByTracking()
    {
        return View("~/Views/Employee/UpdateStatusByTracking.cshtml");
    }

    [HttpPost]
    public IActionResult UpdateStatusByTracking(string trackingNumber)
    {
        var shipment = _context.Shipments.FirstOrDefault(s => s.TrackingNumber == trackingNumber);
        if (shipment == null)
        {
            ViewBag.Error = "Shipment not found.";
            return View("~/Views/Employee/UpdateStatusByTracking.cshtml");
        }

        return RedirectToAction("UpdateStatus", new { shipmentId = shipment.Id });
    }

    [HttpGet("Shipment/DetailsByTracking")]
    public IActionResult Details(string trackingNumber)
    {
        if (string.IsNullOrWhiteSpace(trackingNumber))
            return RedirectToAction("Index", "Home");

        var shipment = _context.Shipments.FirstOrDefault(s => s.TrackingNumber == trackingNumber);

        if (shipment == null)
        {
            TempData["ErrorMessage"] = "Tracking number not found.";
            return RedirectToAction("Index", "Home");
        }

        return View(shipment);
    }

    [HttpGet]
    public IActionResult MyStatusHistory(int? year, int? month)
    {
        var userId = _userManager.GetUserId(User);

        var histories = _context.ShipmentStatusHistories
            .Include(h => h.Shipment)
            .Include(h => h.Branch)
            .Where(h => h.Shipment.AppUserId == userId);

        if (year.HasValue && month.HasValue)
        {
            var firstDay = new DateTime(year.Value, month.Value, 1);
            var lastDay = firstDay.AddMonths(1).AddSeconds(-1);
            histories = histories.Where(h => h.UpdatedAt >= firstDay && h.UpdatedAt <= lastDay);
        }

        ViewBag.SelectedYear = year ?? DateTime.Now.Year;
        ViewBag.SelectedMonth = month ?? DateTime.Now.Month;

        var grouped = histories
            .OrderBy(h => h.UpdatedAt)
            .GroupBy(h => h.ShipmentId)
            .ToList();

        return View("~/Views/Customer/StatusHistory.cshtml", grouped);
    }

}
