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
    public class CartItemDevicesController : Controller
    {
        private readonly IMobileContext _context;

        public CartItemDevicesController(IMobileContext context)
        {
            _context = context;
        }

        // GET: CartItemDevices
        public async Task<IActionResult> Index()
        {
            var iMobileContext = _context.CartItemDevice.Include(c => c.Cart).Include(c => c.Device);
            return View(await iMobileContext.ToListAsync());
        }

        // GET: CartItemDevices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartItemDevice = await _context.CartItemDevice
                .Include(c => c.Cart)
                .Include(c => c.Device)
                .FirstOrDefaultAsync(m => m.CartItemDeviceID == id);
            if (cartItemDevice == null)
            {
                return NotFound();
            }

            return View(cartItemDevice);
        }

        // GET: CartItemDevices/Create
        public IActionResult Create()
        {
            ViewData["CartID"] = new SelectList(_context.Cart, "CartID", "CartID");
            ViewData["DeviceID"] = new SelectList(_context.Set<Device>(), "DeviceID", "Manufacture");
            return View();
        }

        // POST: CartItemDevices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CartItemDeviceID,DeviceID,CartID,Quantity")] CartItemDevice cartItemDevice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cartItemDevice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CartID"] = new SelectList(_context.Cart, "CartID", "CartID", cartItemDevice.CartID);
            ViewData["DeviceID"] = new SelectList(_context.Set<Device>(), "DeviceID", "Manufacture", cartItemDevice.DeviceID);
            return View(cartItemDevice);
        }

        // GET: CartItemDevices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartItemDevice = await _context.CartItemDevice.FindAsync(id);
            if (cartItemDevice == null)
            {
                return NotFound();
            }
            ViewData["CartID"] = new SelectList(_context.Cart, "CartID", "CartID", cartItemDevice.CartID);
            ViewData["DeviceID"] = new SelectList(_context.Set<Device>(), "DeviceID", "Manufacture", cartItemDevice.DeviceID);
            return View(cartItemDevice);
        }

        // POST: CartItemDevices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CartItemDeviceID,DeviceID,CartID,Quantity")] CartItemDevice cartItemDevice)
        {
            if (id != cartItemDevice.CartItemDeviceID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cartItemDevice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartItemDeviceExists(cartItemDevice.CartItemDeviceID))
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
            ViewData["CartID"] = new SelectList(_context.Cart, "CartID", "CartID", cartItemDevice.CartID);
            ViewData["DeviceID"] = new SelectList(_context.Set<Device>(), "DeviceID", "Manufacture", cartItemDevice.DeviceID);
            return View(cartItemDevice);
        }

        // GET: CartItemDevices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartItemDevice = await _context.CartItemDevice
                .Include(c => c.Cart)
                .Include(c => c.Device)
                .FirstOrDefaultAsync(m => m.CartItemDeviceID == id);
            if (cartItemDevice == null)
            {
                return NotFound();
            }

            return View(cartItemDevice);
        }

        // POST: CartItemDevices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cartItemDevice = await _context.CartItemDevice.FindAsync(id);
            _context.CartItemDevice.Remove(cartItemDevice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartItemDeviceExists(int id)
        {
            return _context.CartItemDevice.Any(e => e.CartItemDeviceID == id);
        }
    }
}
