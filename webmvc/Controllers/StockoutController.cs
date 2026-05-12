using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webmvc.Data;
using webmvc.Models.Buoi12;

namespace webmvc.Controllers
{
    public class StockoutController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StockoutController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Stockout
        public async Task<IActionResult> Index()
        {
            return View(await _context.Stockouts.ToListAsync());
        }

        // GET: Stockout/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockout = await _context.Stockouts
                .FirstOrDefaultAsync(m => m.StockoutId == id);
            if (stockout == null)
            {
                return NotFound();
            }

            return View(stockout);
        }

        // GET: Stockout/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stockout/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StockoutId,OrderTime")] Stockout stockout)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stockout);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stockout);
        }

        // GET: Stockout/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockout = await _context.Stockouts.FindAsync(id);
            if (stockout == null)
            {
                return NotFound();
            }
            return View(stockout);
        }

        // POST: Stockout/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StockoutId,OrderTime")] Stockout stockout)
        {
            if (id != stockout.StockoutId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stockout);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockoutExists(stockout.StockoutId))
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
            return View(stockout);
        }

        // GET: Stockout/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockout = await _context.Stockouts
                .FirstOrDefaultAsync(m => m.StockoutId == id);
            if (stockout == null)
            {
                return NotFound();
            }

            return View(stockout);
        }

        // POST: Stockout/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stockout = await _context.Stockouts.FindAsync(id);
            if (stockout != null)
            {
                _context.Stockouts.Remove(stockout);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockoutExists(int id)
        {
            return _context.Stockouts.Any(e => e.StockoutId == id);
        }
    }
}
