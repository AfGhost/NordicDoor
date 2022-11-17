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
    public class KostnadsController : Controller
    {
        private readonly NordicDbContext _context;

        public KostnadsController(NordicDbContext context)
        {
            _context = context;
        }

        // GET: Kostnads
        public async Task<IActionResult> Index()
        {
              return View(await _context.GetKostnads.ToListAsync());
        }

        // GET: Kostnads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GetKostnads == null)
            {
                return NotFound();
            }

            var kostnad = await _context.GetKostnads
                .FirstOrDefaultAsync(m => m.kostnad_id == id);
            if (kostnad == null)
            {
                return NotFound();
            }

            return View(kostnad);
        }

        // GET: Kostnads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kostnads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("kostnad_id,kostnad,med_uten_K,type_K")] Kostnad kostnad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kostnad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kostnad);
        }

        // GET: Kostnads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GetKostnads == null)
            {
                return NotFound();
            }

            var kostnad = await _context.GetKostnads.FindAsync(id);
            if (kostnad == null)
            {
                return NotFound();
            }
            return View(kostnad);
        }

        // POST: Kostnads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("kostnad_id,kostnad,med_uten_K,type_K")] Kostnad kostnad)
        {
            if (id != kostnad.kostnad_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kostnad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KostnadExists(kostnad.kostnad_id))
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
            return View(kostnad);
        }

        // GET: Kostnads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GetKostnads == null)
            {
                return NotFound();
            }

            var kostnad = await _context.GetKostnads
                .FirstOrDefaultAsync(m => m.kostnad_id == id);
            if (kostnad == null)
            {
                return NotFound();
            }

            return View(kostnad);
        }

        // POST: Kostnads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GetKostnads == null)
            {
                return Problem("Entity set 'NordicDbContext.GetKostnads'  is null.");
            }
            var kostnad = await _context.GetKostnads.FindAsync(id);
            if (kostnad != null)
            {
                _context.GetKostnads.Remove(kostnad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KostnadExists(int id)
        {
          return _context.GetKostnads.Any(e => e.kostnad_id == id);
        }
    }
}
