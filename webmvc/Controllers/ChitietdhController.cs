using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webmvc.Data;
using webmvc.Models.Entities;

namespace webmvc.Controllers
{
    public class ChitietdhController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChitietdhController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Chitietdh
        public async Task<IActionResult> Index()
        {
            return View(await _context.Chitietdhs.ToListAsync());
        }

        // GET: Chitietdh/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chitietdh = await _context.Chitietdhs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chitietdh == null)
            {
                return NotFound();
            }

            return View(chitietdh);
        }

        // GET: Chitietdh/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Chitietdh/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Madonhang,Masanpham,Soluong,DonGia")] Chitietdh chitietdh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chitietdh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chitietdh);
        }

        // GET: Chitietdh/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chitietdh = await _context.Chitietdhs.FindAsync(id);
            if (chitietdh == null)
            {
                return NotFound();
            }
            return View(chitietdh);
        }

        // POST: Chitietdh/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Madonhang,Masanpham,Soluong,DonGia")] Chitietdh chitietdh)
        {
            if (id != chitietdh.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chitietdh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChitietdhExists(chitietdh.Id))
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
            return View(chitietdh);
        }

        // GET: Chitietdh/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chitietdh = await _context.Chitietdhs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chitietdh == null)
            {
                return NotFound();
            }

            return View(chitietdh);
        }

        // POST: Chitietdh/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chitietdh = await _context.Chitietdhs.FindAsync(id);
            if (chitietdh != null)
            {
                _context.Chitietdhs.Remove(chitietdh);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChitietdhExists(int id)
        {
            return _context.Chitietdhs.Any(e => e.Id == id);
        }
    }
}
