using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webmvc.Data;
using webmvc.Models.Buoi12;
using webmvc.Models.ViewModels;

namespace webmvc.Controllers
{
    public class StockinController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StockinController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Stockin
        public async Task<IActionResult> Index()
        {
            var data = await _context.Stockins
            .Include(s => s.Stockindts)
            .ToListAsync();

            return View(data);
        }

        // GET: Stockin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockin = await _context.Stockins
                .FirstOrDefaultAsync(m => m.StockinId == id);
            if (stockin == null)
            {
                return NotFound();
            }

            return View(stockin);
        }

        // GET: Stockin/Create
        public IActionResult Create()
        {
            ViewBag.Equipments = _context.Equipments.ToList();
            ViewBag.Devicetypes = _context.Devicetypes.ToList();
            var vm = new StockinVM();

            return View(vm);

        }

        // POST: Stockin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
   
        public async Task<IActionResult> Create(StockinVM model)
        {
            if (!ModelState.IsValid)
            {
            ViewBag.Equipments = _context.Equipments.ToList();
            ViewBag.Devicetypes = _context.Devicetypes.ToList();
            return View(model);
            };
            var stockIn = new Stockin
            {
                OrderTime = model.OrderDate,
            
            };
            await _context.Stockins.AddAsync(stockIn);
            await _context.SaveChangesAsync();

            foreach (var item in model.StockindtVMs)
            {
                var detail = new Stockindt
                {
                    //DevicetypeId = item.DevicetypeId,
                    EquipmentId = item.EquipmentId,
                    UnitPrice = item.ImportPrice,
                    Quantity = item.Quantity,
                    
                };
                await _context.Stockindts.AddAsync(detail);

            }
                await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }

        // GET: Stockin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockin = await _context.Stockins.FindAsync(id);
            if (stockin == null)
            {
                return NotFound();
            }
            return View(stockin);
        }

        // POST: Stockin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StockinId,OrderTime")] Stockin stockin)
        {
            if (id != stockin.StockinId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stockin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockinExists(stockin.StockinId))
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
            return View(stockin);
        }

        // GET: Stockin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stockin = await _context.Stockins
                .FirstOrDefaultAsync(m => m.StockinId == id);
            if (stockin == null)
            {
                return NotFound();
            }

            return View(stockin);
        }

        // POST: Stockin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stockin = await _context.Stockins.FindAsync(id);
            if (stockin != null)
            {
                _context.Stockins.Remove(stockin);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockinExists(int id)
        {
            return _context.Stockins.Any(e => e.StockinId == id);
        }
    }
}
