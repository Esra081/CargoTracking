using CargoTrackingg.Data;
using CargoTrackingg.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CargoTrackingg.Controllers
{
    public class TrackingStatusController : Controller
    {
        private readonly CargoDbContext _context;

        public TrackingStatusController(CargoDbContext context)
        {
            _context = context;
        }

        // GET: TrackingStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.TrackingStatuses.ToListAsync());
        }

        // GET: TrackingStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TrackingStatus/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TrackingStatus status)
        {
            if (ModelState.IsValid)
            {
                _context.Add(status);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(status);
        }

        // GET: TrackingStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var status = await _context.TrackingStatuses.FindAsync(id);
            if (status == null) return NotFound();

            return View(status);
        }

        // POST: TrackingStatus/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TrackingStatus status)
        {
            if (id != status.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(status);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(status);
        }

        // GET: TrackingStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var status = await _context.TrackingStatuses.FirstOrDefaultAsync(s => s.Id == id);
            if (status == null) return NotFound();

            return View(status);
        }

        // POST: TrackingStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var status = await _context.TrackingStatuses.FindAsync(id);
            if (status != null)
            {
                _context.TrackingStatuses.Remove(status);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
