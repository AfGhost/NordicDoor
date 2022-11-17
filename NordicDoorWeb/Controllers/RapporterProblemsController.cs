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
    public class RapporterProblemsController : Controller
    {
        private readonly NordicDbContext _context;

        public RapporterProblemsController(NordicDbContext context)
        {
            _context = context;
        }

        // GET: RapporterProblems
        public async Task<IActionResult> Index()
        {
              return View(await _context.GetRapporterProblems.ToListAsync());
        }

        // GET: RapporterProblems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GetRapporterProblems == null)
            {
                return NotFound();
            }

            var rapporterProblem = await _context.GetRapporterProblems
                .FirstOrDefaultAsync(m => m.rproblem_id == id);
            if (rapporterProblem == null)
            {
                return NotFound();
            }

            return View(rapporterProblem);
        }

        // GET: RapporterProblems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RapporterProblems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("rproblem_id,ansatt_id,problem_tittel,problem_tekst")] RapporterProblem rapporterProblem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rapporterProblem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rapporterProblem);
        }

        // GET: RapporterProblems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GetRapporterProblems == null)
            {
                return NotFound();
            }

            var rapporterProblem = await _context.GetRapporterProblems.FindAsync(id);
            if (rapporterProblem == null)
            {
                return NotFound();
            }
            return View(rapporterProblem);
        }

        // POST: RapporterProblems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("rproblem_id,ansatt_id,problem_tittel,problem_tekst")] RapporterProblem rapporterProblem)
        {
            if (id != rapporterProblem.rproblem_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rapporterProblem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RapporterProblemExists(rapporterProblem.rproblem_id))
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
            return View(rapporterProblem);
        }

        // GET: RapporterProblems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GetRapporterProblems == null)
            {
                return NotFound();
            }

            var rapporterProblem = await _context.GetRapporterProblems
                .FirstOrDefaultAsync(m => m.rproblem_id == id);
            if (rapporterProblem == null)
            {
                return NotFound();
            }

            return View(rapporterProblem);
        }

        // POST: RapporterProblems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GetRapporterProblems == null)
            {
                return Problem("Entity set 'NordicDbContext.GetRapporterProblems'  is null.");
            }
            var rapporterProblem = await _context.GetRapporterProblems.FindAsync(id);
            if (rapporterProblem != null)
            {
                _context.GetRapporterProblems.Remove(rapporterProblem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RapporterProblemExists(int id)
        {
          return _context.GetRapporterProblems.Any(e => e.rproblem_id == id);
        }
    }
}
