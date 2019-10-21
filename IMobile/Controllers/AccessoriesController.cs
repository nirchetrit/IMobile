using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IMobile.Models;

namespace IMobile.Controllers
{
    public class AccessoriesController : Controller
    {
        private readonly IMobileContext _context;

        public AccessoriesController(IMobileContext context)
        {
            _context = context;
        }

        // GET: Accessories
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            //var iMobileContext = _context.Accessorie.Include(a => a.Supplier);
            //return View(await iMobileContext.ToListAsync());

            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
            ViewData["ManufactureSortParm"] = sortOrder == "Manufacture" ? "manufacture_desc" : "Manufacture";
            ViewData["CurrentFilter"] = searchString;


            var accessorie = from s in _context.Accessorie
                          select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                accessorie = accessorie.Where(s => s.Manufacture.Contains(searchString)
                                       || s.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    accessorie = accessorie.OrderByDescending(s => s.Name);
                    break;
                case "Price":
                    accessorie = accessorie.OrderBy(s => s.Price);
                    break;
                case "price_desc":
                    accessorie = accessorie.OrderByDescending(s => s.Price);
                    break;
                default:
                    accessorie = accessorie.OrderBy(s => s.Name);
                    break;
            }
            return View(await accessorie.AsNoTracking().ToListAsync());

        }

        // GET: Accessories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accessorie = await _context.Accessorie
                .Include(a => a.Supplier)
                .FirstOrDefaultAsync(m => m.AccessorieID == id);
            if (accessorie == null)
            {
                return NotFound();
            }

            return View(accessorie);
        }

        // GET: Accessories/Create
        public IActionResult Create()
        {
            ViewData["SupplierID"] = new SelectList(_context.Set<Supplier>(), "SupplierID", "Name");
            return View();
        }

        // POST: Accessories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccessorieID,Name,Manufacture,Price,Description,SupplierID")] Accessorie accessorie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accessorie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SupplierID"] = new SelectList(_context.Set<Supplier>(), "SupplierID", "Name", accessorie.SupplierID);
            return View(accessorie);
        }

        // GET: Accessories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accessorie = await _context.Accessorie.FindAsync(id);
            if (accessorie == null)
            {
                return NotFound();
            }
            ViewData["SupplierID"] = new SelectList(_context.Set<Supplier>(), "SupplierID", "Name", accessorie.SupplierID);
            return View(accessorie);
        }

        // POST: Accessories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccessorieID,Name,Manufacture,Price,Description,SupplierID")] Accessorie accessorie)
        {
            if (id != accessorie.AccessorieID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accessorie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccessorieExists(accessorie.AccessorieID))
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
            ViewData["SupplierID"] = new SelectList(_context.Set<Supplier>(), "SupplierID", "Name", accessorie.SupplierID);
            return View(accessorie);
        }

        // GET: Accessories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accessorie = await _context.Accessorie
                .Include(a => a.Supplier)
                .FirstOrDefaultAsync(m => m.AccessorieID == id);
            if (accessorie == null)
            {
                return NotFound();
            }

            return View(accessorie);
        }

        // POST: Accessories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accessorie = await _context.Accessorie.FindAsync(id);
            _context.Accessorie.Remove(accessorie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccessorieExists(int id)
        {
            return _context.Accessorie.Any(e => e.AccessorieID == id);
        }
    }
}
