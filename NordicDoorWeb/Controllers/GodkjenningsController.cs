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
    public class GodkjenningsController : Controller
    {
        private readonly NordicDbContext _context;

        public GodkjenningsController(NordicDbContext context)
        {
            _context = context;
        }

        // GET: Godkjennings
        public async Task<IActionResult> Index()
        {
              return View(await _context.GetGodkjennings.ToListAsync());
        }

        // GET: Godkjennings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GetGodkjennings == null)
            {
                return NotFound();
            }

            var godkjenning = await _context.GetGodkjennings
                .FirstOrDefaultAsync(m => m.godkjenning_id == id);
            if (godkjenning == null)
            {
                return NotFound();
            }

            return View(godkjenning);
        }

        // GET: Godkjennings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Godkjennings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("godkjenning_id,ansatt_id,gkjent_ikke_gkjent,type_godkjenning")] Godkjenning godkjenning)
        {
            if (ModelState.IsValid)
            {
                _context.Add(godkjenning);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(godkjenning);
        }

        // GET: Godkjennings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GetGodkjennings == null)
            {
                return NotFound();
            }

            var godkjenning = await _context.GetGodkjennings.FindAsync(id);
            if (godkjenning == null)
            {
                return NotFound();
            }
            return View(godkjenning);
        }

        // POST: Godkjennings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("godkjenning_id,ansatt_id,gkjent_ikke_gkjent,type_godkjenning")] Godkjenning godkjenning)
        {
            if (id != godkjenning.godkjenning_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(godkjenning);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GodkjenningExists(godkjenning.godkjenning_id))
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
            return View(godkjenning);
        }

        // GET: Godkjennings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GetGodkjennings == null)
            {
                return NotFound();
            }

            var godkjenning = await _context.GetGodkjennings
                .FirstOrDefaultAsync(m => m.godkjenning_id == id);
            if (godkjenning == null)
            {
                return NotFound();
            }

            return View(godkjenning);
        }

        // POST: Godkjennings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GetGodkjennings == null)
            {
                return Problem("Entity set 'NordicDbContext.GetGodkjennings'  is null.");
            }
            var godkjenning = await _context.GetGodkjennings.FindAsync(id);
            if (godkjenning != null)
            {
                _context.GetGodkjennings.Remove(godkjenning);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GodkjenningExists(int id)
        {
          return _context.GetGodkjennings.Any(e => e.godkjenning_id == id);
        }
    }
}
