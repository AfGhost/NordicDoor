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
    public class AnsattsController : Controller
    {
        private readonly NordicDbContext _context;

        public AnsattsController(NordicDbContext context)
        {
            _context = context;
        }

        // GET: Ansatts
        public async Task<IActionResult> Index()
        {
              return View(await _context.GetAnsatts.ToListAsync());
        }

        // GET: Ansatts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GetAnsatts == null)
            {
                return NotFound();
            }

            var ansatt = await _context.GetAnsatts
                .FirstOrDefaultAsync(m => m.ansatt_id == id);
            if (ansatt == null)
            {
                return NotFound();
            }

            return View(ansatt);
        }

        // GET: Ansatts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ansatts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ansatt_id,epost,passord,ansatt_tilstand,navn_id,teams_id,roller_id,t_medlemmer_id")] Ansatt ansatt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ansatt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ansatt);
        }

        // GET: Ansatts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GetAnsatts == null)
            {
                return NotFound();
            }

            var ansatt = await _context.GetAnsatts.FindAsync(id);
            if (ansatt == null)
            {
                return NotFound();
            }
            return View(ansatt);
        }

        // POST: Ansatts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ansatt_id,epost,passord,ansatt_tilstand,navn_id,teams_id,roller_id,t_medlemmer_id")] Ansatt ansatt)
        {
            if (id != ansatt.ansatt_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ansatt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnsattExists(ansatt.ansatt_id))
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
            return View(ansatt);
        }

        // GET: Ansatts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GetAnsatts == null)
            {
                return NotFound();
            }

            var ansatt = await _context.GetAnsatts
                .FirstOrDefaultAsync(m => m.ansatt_id == id);
            if (ansatt == null)
            {
                return NotFound();
            }

            return View(ansatt);
        }

        // POST: Ansatts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GetAnsatts == null)
            {
                return Problem("Entity set 'NordicDbContext.GetAnsatts'  is null.");
            }
            var ansatt = await _context.GetAnsatts.FindAsync(id);
            if (ansatt != null)
            {
                _context.GetAnsatts.Remove(ansatt);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnsattExists(int id)
        {
          return _context.GetAnsatts.Any(e => e.ansatt_id == id);
        }
    }
}
