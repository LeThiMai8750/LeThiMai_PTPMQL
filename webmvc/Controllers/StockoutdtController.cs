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
    public class StockoutdtController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StockoutdtController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Stockoutdt
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Stockoutdts.Include(s => s.Equipment).Include(s => s.Stockout);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Stockoutdt/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockoutdt = await _context.Stockoutdts
                .Include(s => s.Equipment)
                .Include(s => s.Stockout)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stockoutdt == null)
            {
                return NotFound();
            }

            return View(stockoutdt);
        }

        // GET: Stockoutdt/Create
        public IActionResult Create()
        {
            ViewData["EquipmentId"] = new SelectList(_context.Equipments, "EquipmentId", "EquipmentId");
            ViewData["StockoutId"] = new SelectList(_context.Stockouts, "StockoutId", "StockoutId");
            return View();
        }

        // POST: Stockoutdt/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StockoutId,EquipmentId,Quantity,UnitPrice")] Stockoutdt stockoutdt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stockoutdt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipmentId"] = new SelectList(_context.Equipments, "EquipmentId", "EquipmentId", stockoutdt.EquipmentId);
            ViewData["StockoutId"] = new SelectList(_context.Stockouts, "StockoutId", "StockoutId", stockoutdt.StockoutId);
            return View(stockoutdt);
        }

        // GET: Stockoutdt/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockoutdt = await _context.Stockoutdts.FindAsync(id);
            if (stockoutdt == null)
            {
                return NotFound();
            }
            ViewData["EquipmentId"] = new SelectList(_context.Equipments, "EquipmentId", "EquipmentId", stockoutdt.EquipmentId);
            ViewData["StockoutId"] = new SelectList(_context.Stockouts, "StockoutId", "StockoutId", stockoutdt.StockoutId);
            return View(stockoutdt);
        }

        // POST: Stockoutdt/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StockoutId,EquipmentId,Quantity,UnitPrice")] Stockoutdt stockoutdt)
        {
            if (id != stockoutdt.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stockoutdt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockoutdtExists(stockoutdt.Id))
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
            ViewData["EquipmentId"] = new SelectList(_context.Equipments, "EquipmentId", "EquipmentId", stockoutdt.EquipmentId);
            ViewData["StockoutId"] = new SelectList(_context.Stockouts, "StockoutId", "StockoutId", stockoutdt.StockoutId);
            return View(stockoutdt);
        }

        // GET: Stockoutdt/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockoutdt = await _context.Stockoutdts
                .Include(s => s.Equipment)
                .Include(s => s.Stockout)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stockoutdt == null)
            {
                return NotFound();
            }

            return View(stockoutdt);
        }

        // POST: Stockoutdt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stockoutdt = await _context.Stockoutdts.FindAsync(id);
            if (stockoutdt != null)
            {
                _context.Stockoutdts.Remove(stockoutdt);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockoutdtExists(int id)
        {
            return _context.Stockoutdts.Any(e => e.Id == id);
        }
    }
}
