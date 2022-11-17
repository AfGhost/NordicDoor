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
    public class NavnsController : Controller
    {
        private readonly NordicDbContext _context;

        public NavnsController(NordicDbContext context)
        {
            _context = context;
        }

        // GET: Navns
        public async Task<IActionResult> Index()
        {
              return View(await _context.GetNavns.ToListAsync());
        }

        // GET: Navns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GetNavns == null)
            {
                return NotFound();
            }

            var navn = await _context.GetNavns
                .FirstOrDefaultAsync(m => m.navn_id == id);
            if (navn == null)
            {
                return NotFound();
            }

            return View(navn);
        }

        // GET: Navns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Navns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("navn_id,fornavn,mellomnavn,etternavn,brukernavn")] Navn navn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(navn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(navn);
        }

        // GET: Navns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GetNavns == null)
            {
                return NotFound();
            }

            var navn = await _context.GetNavns.FindAsync(id);
            if (navn == null)
            {
                return NotFound();
            }
            return View(navn);
        }

        // POST: Navns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("navn_id,fornavn,mellomnavn,etternavn,brukernavn")] Navn navn)
        {
            if (id != navn.navn_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(navn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NavnExists(navn.navn_id))
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
            return View(navn);
        }

        // GET: Navns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GetNavns == null)
            {
                return NotFound();
            }

            var navn = await _context.GetNavns
                .FirstOrDefaultAsync(m => m.navn_id == id);
            if (navn == null)
            {
                return NotFound();
            }

            return View(navn);
        }

        // POST: Navns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GetNavns == null)
            {
                return Problem("Entity set 'NordicDbContext.GetNavns'  is null.");
            }
            var navn = await _context.GetNavns.FindAsync(id);
            if (navn != null)
            {
                _context.GetNavns.Remove(navn);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NavnExists(int id)
        {
          return _context.GetNavns.Any(e => e.navn_id == id);
        }
    }
}
