using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ELearning.Entities;
using ELearning.ORM.SqlServer;
using ZebraWeb.Models;
using Microsoft.AspNetCore.Http;

namespace ZebraWeb.Controllers
{
    public class TravelsController : Controller
    {
        private readonly SqlServerDbContext _context;

        public TravelsController(SqlServerDbContext context)
        {
            _context = context;
        }

        // GET: Travels
        public async Task<IActionResult> Index(string TravelsTitle, string sortOrder,
    string currentFilter,
    string searchString,
    int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            var travels= from m in _context.Travels
                         select m;

            if (!String.IsNullOrEmpty(TravelsTitle))
            {
                travels = travels.Where(s => s.TravelsTitle.Contains(TravelsTitle));
            }
            int pageSize = 10;
            return View(await PaginatedList<Travels>.CreateAsync(travels.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Travels/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travels = await _context.Travels.Include(x=>x.TravelNotes)
                .SingleOrDefaultAsync(m => m.TravelsID == id);

            var travelnote = _context.TravelNotes.Where(x => x.TravelsID == id);

            var travelVM = new TraveslVM()
            {
                Like = travels.Like,
                Share = travels.Share,
                TravelsTime = travels.TravelsTime,
                TravelsTitle = travels.TravelsTitle,
                Collection = travels.Collection,
                TravelNotes= travelnote.ToList(),
            };
     
            if (travels == null)
            {
                return NotFound();
            }

           
            return View(travelVM);
        }

        // GET: Travels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Travels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TravelsID,TravelsTitle,travelsTime,Like,Collection,Share")] Travels travels)
        {
            if (ModelState.IsValid)
            {
                travels.TravelsID = Guid.NewGuid();
                _context.Add(travels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(travels);
        }

        // GET: Travels/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travels = await _context.Travels.FindAsync(id);
            if (travels == null)
            {
                return NotFound();
            }
            return View(travels);
        }

        // POST: Travels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("TravelsID,TravelsTitle,travelsTime,Like,Collection,Share")] Travels travels)
        {
            if (id != travels.TravelsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(travels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TravelsExists(travels.TravelsID))
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
            return View(travels);
        }

        // GET: Travels/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travels = await _context.Travels
                .FirstOrDefaultAsync(m => m.TravelsID == id);
            if (travels == null)
            {
                return NotFound();
            }

            return View(travels);
        }

        // POST: Travels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var travels = await _context.Travels.FindAsync(id);
            _context.Travels.Remove(travels);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TravelsExists(Guid id)
        {
            return _context.Travels.Any(e => e.TravelsID == id);
        }

        public IActionResult TravelsIndex()
        {
            var UserId = HttpContext.Session.GetString("User");
            if (UserId != null)
            {
                var User = _context.ApplicationUsers.SingleOrDefault(x => x.Id == Guid.Parse(UserId));
                ViewData["userinfo"] = User;
                ViewBag.img = User.HerdPortrait;
            }
            var travels = _context.Travels.Include(x => x.TravelNotes);
                          
            return View(travels);
        }
        public IActionResult TravelDetails(Guid? id)
        {
            var UserId = HttpContext.Session.GetString("User");
            if (UserId != null)
            {
                var User = _context.ApplicationUsers.SingleOrDefault(x => x.Id == Guid.Parse(UserId));
                ViewData["userinfo"] = User;
                ViewBag.img = User.HerdPortrait;
            }
            var travels = _context.Travels.Include(x => x.TravelNotes).Include(x => x.User).SingleOrDefault(x => x.TravelsID==id);

            return View(travels);
        }
    }
}
