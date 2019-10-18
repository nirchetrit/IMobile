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
    public class CartItemAccsController : Controller
    {
        private readonly IMobileContext _context;

        public CartItemAccsController(IMobileContext context)
        {
            _context = context;
        }

        // GET: CartItemAccs
        public async Task<IActionResult> Index()
        {
            var iMobileContext = _context.CartItemAcc.Include(c => c.Accessorie).Include(c => c.Cart);
            return View(await iMobileContext.ToListAsync());
        }

        // GET: CartItemAccs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartItemAcc = await _context.CartItemAcc
                .Include(c => c.Accessorie)
                .Include(c => c.Cart)
                .FirstOrDefaultAsync(m => m.CartItemAccID == id);
            if (cartItemAcc == null)
            {
                return NotFound();
            }

            return View(cartItemAcc);
        }

        // GET: CartItemAccs/Create
        public IActionResult Create()
        {
            ViewData["AccessorieID"] = new SelectList(_context.Accessorie, "AccessorieID", "Name");
            ViewData["CartID"] = new SelectList(_context.Cart, "CartID", "CartID");
            return View();
        }

        // POST: CartItemAccs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CartItemAccID,AccessorieID,CartID,Quantity")] CartItemAcc cartItemAcc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cartItemAcc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccessorieID"] = new SelectList(_context.Accessorie, "AccessorieID", "Name", cartItemAcc.AccessorieID);
            ViewData["CartID"] = new SelectList(_context.Cart, "CartID", "CartID", cartItemAcc.CartID);
            return View(cartItemAcc);
        }

        // GET: CartItemAccs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartItemAcc = await _context.CartItemAcc.FindAsync(id);
            if (cartItemAcc == null)
            {
                return NotFound();
            }
            ViewData["AccessorieID"] = new SelectList(_context.Accessorie, "AccessorieID", "Name", cartItemAcc.AccessorieID);
            ViewData["CartID"] = new SelectList(_context.Cart, "CartID", "CartID", cartItemAcc.CartID);
            return View(cartItemAcc);
        }

        // POST: CartItemAccs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CartItemAccID,AccessorieID,CartID,Quantity")] CartItemAcc cartItemAcc)
        {
            if (id != cartItemAcc.CartItemAccID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cartItemAcc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartItemAccExists(cartItemAcc.CartItemAccID))
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
            ViewData["AccessorieID"] = new SelectList(_context.Accessorie, "AccessorieID", "Name", cartItemAcc.AccessorieID);
            ViewData["CartID"] = new SelectList(_context.Cart, "CartID", "CartID", cartItemAcc.CartID);
            return View(cartItemAcc);
        }

        // GET: CartItemAccs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartItemAcc = await _context.CartItemAcc
                .Include(c => c.Accessorie)
                .Include(c => c.Cart)
                .FirstOrDefaultAsync(m => m.CartItemAccID == id);
            if (cartItemAcc == null)
            {
                return NotFound();
            }

            return View(cartItemAcc);
        }

        // POST: CartItemAccs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cartItemAcc = await _context.CartItemAcc.FindAsync(id);
            _context.CartItemAcc.Remove(cartItemAcc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartItemAccExists(int id)
        {
            return _context.CartItemAcc.Any(e => e.CartItemAccID == id);
        }
    }
}
