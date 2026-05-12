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
    public class SuplierController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SuplierController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Suplier
        public async Task<IActionResult> Index()
        {
            return View(await _context.Supliers.ToListAsync());
        }

        // GET: Suplier/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suplier = await _context.Supliers
                .FirstOrDefaultAsync(m => m.SuplierId == id);
            if (suplier == null)
            {
                return NotFound();
            }

            return View(suplier);
        }

        // GET: Suplier/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Suplier/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SuplierId,SuplierName")] Suplier suplier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(suplier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(suplier);
        }

        // GET: Suplier/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suplier = await _context.Supliers.FindAsync(id);
            if (suplier == null)
            {
                return NotFound();
            }
            return View(suplier);
        }

        // POST: Suplier/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SuplierId,SuplierName")] Suplier suplier)
        {
            if (id != suplier.SuplierId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(suplier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuplierExists(suplier.SuplierId))
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
            return View(suplier);
        }

        // GET: Suplier/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var suplier = await _context.Supliers
                .FirstOrDefaultAsync(m => m.SuplierId == id);
            if (suplier == null)
            {
                return NotFound();
            }

            return View(suplier);
        }

        // POST: Suplier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var suplier = await _context.Supliers.FindAsync(id);
            if (suplier != null)
            {
                _context.Supliers.Remove(suplier);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuplierExists(int id)
        {
            return _context.Supliers.Any(e => e.SuplierId == id);
        }
    }
}
