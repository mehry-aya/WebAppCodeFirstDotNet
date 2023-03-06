using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppCodeFirst.Data;
using WebAppCodeFirst.Models;

namespace WebAppCodeFirst.Controllers
{
    public class AppreciationsController : Controller
    {
        private readonly WebAppCodeFirstDbContext _context;

        public AppreciationsController(WebAppCodeFirstDbContext context)
        {
            _context = context;
        }

        // GET: Appreciations
        public async Task<IActionResult> Index()
        {
            var webAppCodeFirstDbContext = _context.Appreciation.Include(a => a.Hotel);
            return View(await webAppCodeFirstDbContext.ToListAsync());
        }

        // GET: Appreciations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Appreciation == null)
            {
                return NotFound();
            }

            var appreciation = await _context.Appreciation
                .Include(a => a.Hotel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appreciation == null)
            {
                return NotFound();
            }

            return View(appreciation);
        }

        // GET: Appreciations/Create
        public IActionResult Create()
        {
            ViewData["HotelId"] = new SelectList(_context.Hotel, "Id", "Nom");
            return View();
        }

        // POST: Appreciations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Comment,HotelId")] Appreciation appreciation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appreciation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotelId"] = new SelectList(_context.Hotel, "Id", "Nom", appreciation.HotelId);
            return View(appreciation);
        }

        // GET: Appreciations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Appreciation == null)
            {
                return NotFound();
            }

            var appreciation = await _context.Appreciation.FindAsync(id);
            if (appreciation == null)
            {
                return NotFound();
            }
            ViewData["HotelId"] = new SelectList(_context.Hotel, "Id", "Nom", appreciation.HotelId);
            return View(appreciation);
        }

        // POST: Appreciations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Comment,HotelId")] Appreciation appreciation)
        {
            if (id != appreciation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appreciation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppreciationExists(appreciation.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["HotelId"] = new SelectList(_context.Hotel, "Id", "Nom", appreciation.HotelId);
            return View(appreciation);
        }

        // GET: Appreciations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Appreciation == null)
            {
                return NotFound();
            }

            var appreciation = await _context.Appreciation
                .Include(a => a.Hotel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appreciation == null)
            {
                return NotFound();
            }

            return View(appreciation);
        }

        // POST: Appreciations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Appreciation == null)
            {
                return Problem("Entity set 'WebAppCodeFirstDbContext.Appreciation'  is null.");
            }
            var appreciation = await _context.Appreciation.FindAsync(id);
            if (appreciation != null)
            {
                _context.Appreciation.Remove(appreciation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppreciationExists(int id)
        {
          return _context.Appreciation.Any(e => e.Id == id);
        }
    }
}
