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
    public class FremdriftsController : Controller
    {
        private readonly NordicDbContext _context;

        public FremdriftsController(NordicDbContext context)
        {
            _context = context;
        }

        // GET: Fremdrifts
        public async Task<IActionResult> Index()
        {
              return View(await _context.GetFremdrifts.ToListAsync());
        }

        // GET: Fremdrifts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GetFremdrifts == null)
            {
                return NotFound();
            }

            var fremdrift = await _context.GetFremdrifts
                .FirstOrDefaultAsync(m => m.fremdrift_id == id);
            if (fremdrift == null)
            {
                return NotFound();
            }

            return View(fremdrift);
        }

        // GET: Fremdrifts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fremdrifts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("fremdrift_id,status_id,forslag_id,fremgang,aktiv_ikke_aktiv,type_aktiv,prosentvis_fullført,tildelt_team")] Fremdrift fremdrift)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fremdrift);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fremdrift);
        }

        // GET: Fremdrifts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GetFremdrifts == null)
            {
                return NotFound();
            }

            var fremdrift = await _context.GetFremdrifts.FindAsync(id);
            if (fremdrift == null)
            {
                return NotFound();
            }
            return View(fremdrift);
        }

        // POST: Fremdrifts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("fremdrift_id,status_id,forslag_id,fremgang,aktiv_ikke_aktiv,type_aktiv,prosentvis_fullført,tildelt_team")] Fremdrift fremdrift)
        {
            if (id != fremdrift.fremdrift_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fremdrift);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FremdriftExists(fremdrift.fremdrift_id))
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
            return View(fremdrift);
        }

        // GET: Fremdrifts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GetFremdrifts == null)
            {
                return NotFound();
            }

            var fremdrift = await _context.GetFremdrifts
                .FirstOrDefaultAsync(m => m.fremdrift_id == id);
            if (fremdrift == null)
            {
                return NotFound();
            }

            return View(fremdrift);
        }

        // POST: Fremdrifts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GetFremdrifts == null)
            {
                return Problem("Entity set 'NordicDbContext.GetFremdrifts'  is null.");
            }
            var fremdrift = await _context.GetFremdrifts.FindAsync(id);
            if (fremdrift != null)
            {
                _context.GetFremdrifts.Remove(fremdrift);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FremdriftExists(int id)
        {
          return _context.GetFremdrifts.Any(e => e.fremdrift_id == id);
        }
    }
}
