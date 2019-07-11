using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ELearning.Entities;
using ELearning.ORM.SqlServer;

namespace ELZebra.Controllers
{
    public class LabelsController : Controller
    {
        private readonly SqlServerDbContext _context;

        public LabelsController(SqlServerDbContext context)
        {
            _context = context;
        }

        // GET: Labels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Label.ToListAsync());
        }

        // GET: Labels/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var label = await _context.Label
                .FirstOrDefaultAsync(m => m.Id == id);
            if (label == null)
            {
                return NotFound();
            }

            return View(label);
        }

        // GET: Labels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Labels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LabelName")] Label label)
        {
            if (ModelState.IsValid)
            {
                label.Id = Guid.NewGuid();
                _context.Add(label);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(label);
        }

        // GET: Labels/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var label = await _context.Label.FindAsync(id);
            if (label == null)
            {
                return NotFound();
            }
            return View(label);
        }

        // POST: Labels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,LabelName")] Label label)
        {
            if (id != label.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(label);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LabelExists(label.Id))
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
            return View(label);
        }

        // GET: Labels/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var label = await _context.Label
                .FirstOrDefaultAsync(m => m.Id == id);
            if (label == null)
            {
                return NotFound();
            }

            return View(label);
        }

        // POST: Labels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var label = await _context.Label.FindAsync(id);
            _context.Label.Remove(label);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LabelExists(Guid id)
        {
            return _context.Label.Any(e => e.Id == id);
        }
    }
}
