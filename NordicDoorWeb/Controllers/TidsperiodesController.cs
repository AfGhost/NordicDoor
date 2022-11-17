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
    public class TidsperiodesController : Controller
    {
        private readonly NordicDbContext _context;

        public TidsperiodesController(NordicDbContext context)
        {
            _context = context;
        }

        // GET: Tidsperiodes
        public async Task<IActionResult> Index()
        {
              return View(await _context.GetTidsperiode.ToListAsync());
        }

        // GET: Tidsperiodes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GetTidsperiode == null)
            {
                return NotFound();
            }

            var tidsperiode = await _context.GetTidsperiode
                .FirstOrDefaultAsync(m => m.tperiode_id == id);
            if (tidsperiode == null)
            {
                return NotFound();
            }

            return View(tidsperiode);
        }

        // GET: Tidsperiodes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tidsperiodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("tperiode_id,varighet,tperiode,type_tid")] Tidsperiode tidsperiode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tidsperiode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tidsperiode);
        }

        // GET: Tidsperiodes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GetTidsperiode == null)
            {
                return NotFound();
            }

            var tidsperiode = await _context.GetTidsperiode.FindAsync(id);
            if (tidsperiode == null)
            {
                return NotFound();
            }
            return View(tidsperiode);
        }

        // POST: Tidsperiodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("tperiode_id,varighet,tperiode,type_tid")] Tidsperiode tidsperiode)
        {
            if (id != tidsperiode.tperiode_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tidsperiode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TidsperiodeExists(tidsperiode.tperiode_id))
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
            return View(tidsperiode);
        }

        // GET: Tidsperiodes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GetTidsperiode == null)
            {
                return NotFound();
            }

            var tidsperiode = await _context.GetTidsperiode
                .FirstOrDefaultAsync(m => m.tperiode_id == id);
            if (tidsperiode == null)
            {
                return NotFound();
            }

            return View(tidsperiode);
        }

        // POST: Tidsperiodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GetTidsperiode == null)
            {
                return Problem("Entity set 'NordicDbContext.GetTidsperiode'  is null.");
            }
            var tidsperiode = await _context.GetTidsperiode.FindAsync(id);
            if (tidsperiode != null)
            {
                _context.GetTidsperiode.Remove(tidsperiode);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TidsperiodeExists(int id)
        {
          return _context.GetTidsperiode.Any(e => e.tperiode_id == id);
        }
    }
}
