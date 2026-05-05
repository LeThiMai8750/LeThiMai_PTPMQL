using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webmvc.Data;
using webmvc.Models.Entities;
using webmvc.Models.ViewModels;

namespace webmvc.Controllers
{
    public class DonhangController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DonhangController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Donhang
        public IActionResult Index()
        {
            var list = _context.Donhangs.Include(d => d.Khachhang).Select(d => new DonHangListVM
            {
                Id = d.Madonhang,
                TenKhachHang = d.Khachhang.TenKhachHang,
                NgayDat = d.NgayDat
            })
            .ToList();
            return View(list);
        }

        // GET: Donhang/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donhang = await _context.Donhangs
                .FirstOrDefaultAsync(m => m.Madonhang == id);
            if (donhang == null)
            {
                return NotFound();
            }

            return View(donhang);
        }

        // GET: Donhang/Create
        public IActionResult Create()
        {
            var vm = new CreateDonHangVM();
            vm.Chitietdhs = new List<Chitietdh>
            {
                new Chitietdh()
            };



            return View(vm);
        }

        // POST: Donhang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Madonhang,NgayDat,MaKhachHang")] Donhang donhang)
        {

            var last = _context.Donhangs
            .OrderByDescending(d => d.Madonhang)
            .FirstOrDefault();

            string newId = "DH001"; if (last != null)
            {
                int num = int.Parse(last.Madonhang.Substring(2));
                newId = "DH" + (num + 1).ToString("D3");
            }


            if (ModelState.IsValid)
            {
                _context.Add(donhang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(donhang);
        }

        // GET: Donhang/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donhang = await _context.Donhangs.FindAsync(id);
            if (donhang == null)
            {
                return NotFound();
            }
            return View(donhang);
        }

        // POST: Donhang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Madonhang,NgayDat,MaKhachHang")] Donhang donhang)
        {
            if (id != donhang.Madonhang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donhang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonhangExists(donhang.Madonhang))
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
            return View(donhang);
        }

        // GET: Donhang/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donhang = await _context.Donhangs
                .FirstOrDefaultAsync(m => m.Madonhang == id);
            if (donhang == null)
            {
                return NotFound();
            }

            return View(donhang);
        }

        // POST: Donhang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var donhang = await _context.Donhangs.FindAsync(id);
            if (donhang != null)
            {
                _context.Donhangs.Remove(donhang);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonhangExists(string id)
        {
            return _context.Donhangs.Any(e => e.Madonhang == id);
        }
    }
}
