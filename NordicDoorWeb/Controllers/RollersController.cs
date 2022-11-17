using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NordicDoorWeb.Data;
using NordicDoorWeb.Models;

namespace NordicDoorWeb.Controllers
{
    public class RollersController : Controller
    {
        private readonly NordicDbContext _context;

        public RollersController(NordicDbContext context)
        {
            _context = context;
        }

        // GET: Rollers
        public async Task<IActionResult> Index()
        {
              return View(await _context.GetRollers.ToListAsync());
        }

        // GET: Rollers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GetRollers == null)
            {
                return NotFound();
            }

            var roller = await _context.GetRollers
                .FirstOrDefaultAsync(m => m.roller_id == id);
            if (roller == null)
            {
                return NotFound();
            }

            return View(roller);
        }

        // GET: Rollers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rollers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("roller_id,rolle,grad")] Roller roller)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roller);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roller);
        }

        // GET: Rollers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GetRollers == null)
            {
                return NotFound();
            }

            var roller = await _context.GetRollers.FindAsync(id);
            if (roller == null)
            {
                return NotFound();
            }
            return View(roller);
        }

        // POST: Rollers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("roller_id,rolle,grad")] Roller roller)
        {
            if (id != roller.roller_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roller);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RollerExists(roller.roller_id))
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
            return View(roller);
        }

        // GET: Rollers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GetRollers == null)
            {
                return NotFound();
            }

            var roller = await _context.GetRollers
                .FirstOrDefaultAsync(m => m.roller_id == id);
            if (roller == null)
            {
                return NotFound();
            }

            return View(roller);
        }

        // POST: Rollers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GetRollers == null)
            {
                return Problem("Entity set 'NordicDbContext.GetRollers'  is null.");
            }
            var roller = await _context.GetRollers.FindAsync(id);
            if (roller != null)
            {
                _context.GetRollers.Remove(roller);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RollerExists(int id)
        {
          return _context.GetRollers.Any(e => e.roller_id == id);
        }
    }
}
