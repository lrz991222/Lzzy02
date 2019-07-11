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
    public class ScenicSpotsController : Controller
    {
        private readonly SqlServerDbContext _context;

        public ScenicSpotsController(SqlServerDbContext context)
        {
            _context = context;
        }
        //1
        // GET: ScenicSpots
        public async Task<IActionResult> Index(string ScenicSpots, string sortOrder,
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

            IQueryable<ScenicSpot> scenicSpots = _context.ScenicSpot.Include(x => x.Theme).Include(x => x.Label);


            if (!String.IsNullOrEmpty(ScenicSpots))
            {
                scenicSpots = scenicSpots.Where(s => s.Name.Contains(ScenicSpots));
            }


            int pageSize = 10;
            return View(await PaginatedList<ScenicSpot>.CreateAsync(scenicSpots.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: ScenicSpots/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scenicSpot = await _context.ScenicSpot
                .FirstOrDefaultAsync(m => m.Id == id);
            if (scenicSpot == null)
            {
                return NotFound();
            }

            return View(scenicSpot);
        }

        // GET: ScenicSpots/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ScenicSpots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Grade,Lng,Lat,Addr,Type,Opentime,Tel,Url")] ScenicSpot scenicSpot)
        {
            if (ModelState.IsValid)
            {
                scenicSpot.Id = Guid.NewGuid();
                _context.Add(scenicSpot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(scenicSpot);
        }

        // GET: ScenicSpots/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            IQueryable<string> Themes = from m in _context.Themes
                                            orderby m.themeName
                                            select m.themeName;
            IQueryable<string> Labels= from m in _context.Label
                                        orderby m.LabelName
                                        select m.LabelName;
            if (id == null)
            {
                return NotFound();
            }

            var scenicSpot = await _context.ScenicSpot.FindAsync(id);
            if (scenicSpot == null)
            {
                return NotFound();
            }

            var theme = _context.Themes.ToList();
            var label = _context.Label.ToList();

            var scenicspotVM = new ScenicSpotVM
            {
                Addr = scenicSpot.Addr,
                Grade=scenicSpot.Grade,
                Lat=scenicSpot.Lat,
                Lng=scenicSpot.Lng,
                Opentime=scenicSpot.Opentime,
                Name=scenicSpot.Name,
                Tel=scenicSpot.Tel,
                Url=scenicSpot.Url,
                Type=scenicSpot.Type,
                Label=label,
                Theme= theme,
               
            };
            ViewBag.Label = scenicSpot.Label.LabelName;
            ViewBag.Theme = scenicSpot.Theme.themeName;
            return View(scenicspotVM);
        }

        // POST: ScenicSpots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Grade,Name,Lng,Lat,Addr,Type,Opentime,Tel,Url")] ScenicSpot scenicSpot,string themeName, string labelname)
        {

     
            if (id != scenicSpot.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    scenicSpot.Theme = _context.Themes.SingleOrDefault(x => x.themeName == themeName);
                    scenicSpot.Label = _context.Label.SingleOrDefault(x => x.LabelName == labelname);

                    _context.Update(scenicSpot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScenicSpotExists(scenicSpot.Id))
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
          
           
            return View(scenicSpot);
        }

        // GET: ScenicSpots/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scenicSpot = await _context.ScenicSpot
                .FirstOrDefaultAsync(m => m.Id == id);
            if (scenicSpot == null)
            {
                return NotFound();
            }

            return View(scenicSpot);
        }

        // POST: ScenicSpots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var scenicSpot = await _context.ScenicSpot.FindAsync(id);
            _context.ScenicSpot.Remove(scenicSpot);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScenicSpotExists(Guid id)
        {
            return _context.ScenicSpot.Any(e => e.Id == id);
        }


        public IActionResult ScenicSpotsIndex()
        {
            var UserId = HttpContext.Session.GetString("User");
            if (UserId != null)
            {
                var User = _context.ApplicationUsers.SingleOrDefault(x => x.Id == Guid.Parse(UserId));
                ViewData["userinfo"] = User;
                ViewBag.img = User.HerdPortrait;
            }
            var scenicSpots = _context.ScenicSpot.Include(x => x.Theme).Include(x => x.Label);
            return View(scenicSpots);
        }
        public IActionResult ScenicSpotsDetails(Guid? id)
        {
            var UserId = HttpContext.Session.GetString("User");
            if (UserId != null)
            {
                var User = _context.ApplicationUsers.SingleOrDefault(x => x.Id == Guid.Parse(UserId));
                ViewData["userinfo"] = User;
                ViewBag.img = User.HerdPortrait;
            }
            var travels = _context.ScenicSpot.Include(x => x.Label).Include(x => x.Theme).SingleOrDefault(x => x.Id == id);

            return View(travels);
        }
    }
}
