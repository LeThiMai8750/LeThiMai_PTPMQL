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
    public class DevicetypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DevicetypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Devicetype
        public async Task<IActionResult> Index()
        {
            return View(await _context.Devicetypes.ToListAsync());
        }

        // GET: Devicetype/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var devicetype = await _context.Devicetypes
                .FirstOrDefaultAsync(m => m.DevicetypeId == id);
            if (devicetype == null)
            {
                return NotFound();
            }

            return View(devicetype);
        }

        // GET: Devicetype/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Devicetype/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DevicetypeId,DevicetypeName,Price,Stock")] Devicetype devicetype)
        {
            if (ModelState.IsValid)
            {
                _context.Add(devicetype);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(devicetype);
        }

        // GET: Devicetype/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var devicetype = await _context.Devicetypes.FindAsync(id);
            if (devicetype == null)
            {
                return NotFound();
            }
            return View(devicetype);
        }

        // POST: Devicetype/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DevicetypeId,DevicetypeName,Price,Stock")] Devicetype devicetype)
        {
            if (id != devicetype.DevicetypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(devicetype);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DevicetypeExists(devicetype.DevicetypeId))
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
            return View(devicetype);
        }

        // GET: Devicetype/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var devicetype = await _context.Devicetypes
                .FirstOrDefaultAsync(m => m.DevicetypeId == id);
            if (devicetype == null)
            {
                return NotFound();
            }

            return View(devicetype);
        }

        // POST: Devicetype/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var devicetype = await _context.Devicetypes.FindAsync(id);
            if (devicetype != null)
            {
                _context.Devicetypes.Remove(devicetype);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DevicetypeExists(int id)
        {
            return _context.Devicetypes.Any(e => e.DevicetypeId == id);
        }
    }
}
