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
using ELearning.DataAccess.Tools;
using ZebraWeb.Sundry;

namespace ZebraWeb.Controllers
{
    public class CitiesController : Controller
    {
        private readonly SqlServerDbContext _context;

        public CitiesController(SqlServerDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string Genres, string CitCityName, 
            string sortOrder,
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


            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Citys
                                            orderby m.Province
                                            select m.Province;
            
            var cities = from m in _context.Citys
                         select m;
            
            if (!string.IsNullOrEmpty(CitCityName))
            {
                cities = cities.Where(s => s.CityName.Contains(CitCityName));
            }

            if (!string.IsNullOrEmpty(Genres))
            {
                cities = cities.Where(x => x.Province == Genres);
            }

            var cityVM = new CityVM
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Cities = await cities.ToListAsync()
            };
            
            
            int pageSize = 3;

            return View(cityVM);
         
            //return View (await ModelList<CityVM>.CitiesAsync(cityVM, pageNumber ?? 1, pageSize,_context));
        
        }
       
        // GET: Cities/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.Citys
                .FirstOrDefaultAsync(m => m.Id == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // GET: Cities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CityName,Province")] City city)
        {
            if (ModelState.IsValid)
            {
                city.Id = Guid.NewGuid();
                _context.Add(city);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(city);
        }

        // GET: Cities/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.Citys.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            return View(city);
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,CityName,Province")] City city)
        {
            if (id != city.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(city);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CityExists(city.Id))
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
            return View(city);
        }

        // GET: Cities/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.Citys
                .FirstOrDefaultAsync(m => m.Id == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // POST: Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var city = await _context.Citys.FindAsync(id);
            _context.Citys.Remove(city);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CityExists(Guid id)
        {
            return _context.Citys.Any(e => e.Id == id);
        }
       
        }
    }
