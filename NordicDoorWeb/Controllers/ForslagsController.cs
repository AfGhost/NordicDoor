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
    public class ForslagsController : Controller
    {
        private readonly NordicDbContext _context;

        public ForslagsController(NordicDbContext context)
        {
            _context = context;
        }

        // GET: Forslags
        public async Task<IActionResult> Index()
        {
              return View(await _context.GetForslags.ToListAsync());
        }

        // GET: Forslags/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GetForslags == null)
            {
                return NotFound();
            }

            var forslag = await _context.GetForslags
                .FirstOrDefaultAsync(m => m.forslag_id == id);
            if (forslag == null)
            {
                return NotFound();
            }

            return View(forslag);
        }

        // GET: Forslags/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Forslags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("forslag_id,ansatt_id,tittel,nyttforslag,årsak,mål,løsning,dato_registrert,frist,Bilde,navn_id,ansvarlig,tperiode_id,kostnad_id,teams_id,gkjenning_id,status_id")] Forslag forslag)
        {
            if (ModelState.IsValid)
            {
                _context.Add(forslag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(forslag);
        }

        // GET: Forslags/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GetForslags == null)
            {
                return NotFound();
            }

            var forslag = await _context.GetForslags.FindAsync(id);
            if (forslag == null)
            {
                return NotFound();
            }
            return View(forslag);
        }

        // POST: Forslags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("forslag_id,ansatt_id,tittel,nyttforslag,årsak,mål,løsning,dato_registrert,frist,Bilde,navn_id,ansvarlig,tperiode_id,kostnad_id,teams_id,gkjenning_id,status_id")] Forslag forslag)
        {
            if (id != forslag.forslag_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(forslag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ForslagExists(forslag.forslag_id))
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
            return View(forslag);
        }

        // GET: Forslags/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GetForslags == null)
            {
                return NotFound();
            }

            var forslag = await _context.GetForslags
                .FirstOrDefaultAsync(m => m.forslag_id == id);
            if (forslag == null)
            {
                return NotFound();
            }

            return View(forslag);
        }

        // POST: Forslags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GetForslags == null)
            {
                return Problem("Entity set 'NordicDbContext.GetForslags'  is null.");
            }
            var forslag = await _context.GetForslags.FindAsync(id);
            if (forslag != null)
            {
                _context.GetForslags.Remove(forslag);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ForslagExists(int id)
        {
          return _context.GetForslags.Any(e => e.forslag_id == id);
        }
    }
}
