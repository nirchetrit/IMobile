using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IMobile.Models;
using Microsoft.AspNetCore.Authorization;

namespace IMobile.Controllers
{
    [Authorize]
    
    public class DevicesController : Controller
    {
        private readonly IMobileContext _context;

        public DevicesController(IMobileContext context)
        {
            _context = context;
        }

        // GET: Devices
        public async Task<IActionResult> Index(string sortOrder, string searchString, String Manufacture, int minprice, int maxprice, int minram, int maxram)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_desc" : "Price";
            ViewData["ManufactureSortParm"] = sortOrder == "Manufacture" ? "manufacture_desc" : "Manufacture";
            ViewData["MemorySortParm"] = sortOrder == "Memory" ? "memory_desc" : "Memory";
            ViewData["CurrentFilter"] = searchString;


            var devices = from s in _context.Device
                          select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                devices = devices.Where(s => s.Manufacture.Contains(searchString)
                                       || s.Name.Contains(searchString));
            }


            if (Manufacture != null)
            {
                devices = devices.Where(s => s.Manufacture.Contains(Manufacture));
            }
            if (minprice != 0)
            {
                devices = devices.Where(s => s.Price > minprice);
            }
            if (maxprice != 0)
            {
                devices = devices.Where(s => s.Price < maxprice);
            }
            if (minram != 0)
            {
                devices = devices.Where(s => s.Price > minram);
            }
            if (maxram != 0)
            {
                devices = devices.Where(s => s.Price < maxram);
            }

            switch (sortOrder)
            {
                case "name_desc":
                    devices = devices.OrderByDescending(s => s.Name);
                    break;
                case "Price":
                    devices = devices.OrderBy(s => s.Price);
                    break;
                case "price_desc":
                    devices = devices.OrderByDescending(s => s.Price);
                    break;
                case "Memory":
                    devices = devices.OrderBy(s => s.Memory);
                    break;
                case "memory_desc":
                    devices = devices.OrderByDescending(s => s.Memory);
                    break;
                default:
                    devices = devices.OrderBy(s => s.Name);
                    break;
            }
            return View(await devices.AsNoTracking().ToListAsync());
        }

        // GET: Devices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = await _context.Device
                .Include(d => d.Supplier)
                .FirstOrDefaultAsync(m => m.DeviceID == id);
            if (device == null)
            {
                return NotFound();
            }
            device.ViewCounter++;
            try
            {
                _context.Update(device);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceExists(device.DeviceID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return View(device);
        }

        // GET: Devices/Create
        [Area("Admin")]
        public IActionResult Create()
        {
            ViewData["SupplierID"] = new SelectList(_context.Supplier, "SupplierID", "Name");
            return View();
        }

        // POST: Devices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Area("Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeviceID,Manufacture,Name,ImageUrl,Description,Price,ScreenSize,Memory,RamMemory,SupplierID")] Device device)
        {
            if (ModelState.IsValid)
            {
                _context.Add(device);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SupplierID"] = new SelectList(_context.Supplier, "SupplierID", "Name", device.SupplierID);
            return View(device);
        }

        // GET: Devices/Edit/5
        [Area("Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = await _context.Device.FindAsync(id);
            if (device == null)
            {
                return NotFound();
            }
            ViewData["SupplierID"] = new SelectList(_context.Supplier, "SupplierID", "Name", device.SupplierID);
            return View(device);
        }

        // POST: Devices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Area("Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("DeviceID,Manufacture,Name,ImageUrl,Description,Price,ScreenSize,Memory,RamMemory,SupplierID")] Device device)
        {
            if (id != device.DeviceID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(device);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeviceExists(device.DeviceID))
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
            ViewData["SupplierID"] = new SelectList(_context.Supplier, "SupplierID", "Name", device.SupplierID);
            return View(device);
        }

        // GET: Devices/Delete/5
        [Area("Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = await _context.Device
                .Include(d => d.Supplier)
                .FirstOrDefaultAsync(m => m.DeviceID == id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // POST: Devices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var device = await _context.Device.FindAsync(id);
            _context.Device.Remove(device);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeviceExists(int id)
        {
            return _context.Device.Any(e => e.DeviceID == id);
        }




        public async Task<IActionResult> Statistics()
        {
            var devices = from s in _context.Device
                          select s;
            if (devices == null)
            {
                return NotFound();
            }

            return View(await devices.AsNoTracking().ToListAsync());

        }



    }
}
