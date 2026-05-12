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
    public class StockindtController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StockindtController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Stockindt
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Stockindts.Include(s => s.Equipment).Include(s => s.Stockin);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Stockindt/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockindt = await _context.Stockindts
                .Include(s => s.Equipment)
                .Include(s => s.Stockin)
                .FirstOrDefaultAsync(m => m.StockindtId == id);
            if (stockindt == null)
            {
                return NotFound();
            }

            return View(stockindt);
        }

        // GET: Stockindt/Create
        public IActionResult Create()
        {
            ViewData["EquipmentId"] = new SelectList(_context.Equipments, "EquipmentId", "EquipmentName");
            ViewData["StockinId"] = new SelectList(_context.Stockins, "StockinId", "StockinId");
            return View();
        }

        // POST: Stockindt/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StockindtId,StockinId,EquipmentId,Quantity,UnitPrice")] Stockindt stockindt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stockindt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EquipmentId"] = new SelectList(_context.Equipments, "EquipmentId", "EquipmentName", stockindt.EquipmentId);
            ViewData["StockinId"] = new SelectList(_context.Stockins, "StockinId", "StockinId", stockindt.StockinId);
            return View(stockindt);
        }

        // GET: Stockindt/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockindt = await _context.Stockindts.FindAsync(id);
            if (stockindt == null)
            {
                return NotFound();
            }
            ViewData["EquipmentId"] = new SelectList(_context.Equipments, "EquipmentId", "EquipmentName", stockindt.EquipmentId);
            ViewData["StockinId"] = new SelectList(_context.Stockins, "StockinId", "StockinId", stockindt.StockinId);
            return View(stockindt);
        }

        // POST: Stockindt/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StockindtId,StockinId,EquipmentId,Quantity,UnitPrice")] Stockindt stockindt)
        {
            if (id != stockindt.StockindtId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stockindt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockindtExists(stockindt.StockindtId))
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
            ViewData["EquipmentId"] = new SelectList(_context.Equipments, "EquipmentId", "EquipmentName", stockindt.EquipmentId);
            ViewData["StockinId"] = new SelectList(_context.Stockins, "StockinId", "StockinId", stockindt.StockinId);
            return View(stockindt);
        }

        // GET: Stockindt/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockindt = await _context.Stockindts
                .Include(s => s.Equipment)
                .Include(s => s.Stockin)
                .FirstOrDefaultAsync(m => m.StockindtId == id);
            if (stockindt == null)
            {
                return NotFound();
            }

            return View(stockindt);
        }

        // POST: Stockindt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stockindt = await _context.Stockindts.FindAsync(id);
            if (stockindt != null)
            {
                _context.Stockindts.Remove(stockindt);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockindtExists(int id)
        {
            return _context.Stockindts.Any(e => e.StockindtId == id);
        }
    }
}
