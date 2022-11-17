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
    public class T_medlemmerController : Controller
    {
        private readonly NordicDbContext _context;

        public T_medlemmerController(NordicDbContext context)
        {
            _context = context;
        }

        // GET: T_medlemmer
        public async Task<IActionResult> Index()
        {
              return View(await _context.GetT_medlemmer.ToListAsync());
        }

        // GET: T_medlemmer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GetT_medlemmer == null)
            {
                return NotFound();
            }

            var t_medlemmer = await _context.GetT_medlemmer
                .FirstOrDefaultAsync(m => m.t_medlemmer_id == id);
            if (t_medlemmer == null)
            {
                return NotFound();
            }

            return View(t_medlemmer);
        }

        // GET: T_medlemmer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: T_medlemmer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("t_medlemmer_id,navn_id,teams_id")] T_medlemmer t_medlemmer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(t_medlemmer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(t_medlemmer);
        }

        // GET: T_medlemmer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GetT_medlemmer == null)
            {
                return NotFound();
            }

            var t_medlemmer = await _context.GetT_medlemmer.FindAsync(id);
            if (t_medlemmer == null)
            {
                return NotFound();
            }
            return View(t_medlemmer);
        }

        // POST: T_medlemmer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("t_medlemmer_id,navn_id,teams_id")] T_medlemmer t_medlemmer)
        {
            if (id != t_medlemmer.t_medlemmer_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(t_medlemmer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!T_medlemmerExists(t_medlemmer.t_medlemmer_id))
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
            return View(t_medlemmer);
        }

        // GET: T_medlemmer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GetT_medlemmer == null)
            {
                return NotFound();
            }

            var t_medlemmer = await _context.GetT_medlemmer
                .FirstOrDefaultAsync(m => m.t_medlemmer_id == id);
            if (t_medlemmer == null)
            {
                return NotFound();
            }

            return View(t_medlemmer);
        }

        // POST: T_medlemmer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GetT_medlemmer == null)
            {
                return Problem("Entity set 'NordicDbContext.GetT_medlemmer'  is null.");
            }
            var t_medlemmer = await _context.GetT_medlemmer.FindAsync(id);
            if (t_medlemmer != null)
            {
                _context.GetT_medlemmer.Remove(t_medlemmer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool T_medlemmerExists(int id)
        {
          return _context.GetT_medlemmer.Any(e => e.t_medlemmer_id == id);
        }
    }
}
