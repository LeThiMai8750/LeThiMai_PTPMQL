using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webmvc.Data;
using webmvc.Models.Demo;
using webmvc.Models.ViewModels;

namespace webmvc.Controllers
{
    public class PictureController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PictureController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Picture
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Picture.Include(p => p.Author); 
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Picture/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var picture = await _context.Picture
                .Include(p => p.Author)
                .FirstOrDefaultAsync(m => m.Id == id); // trả về kết quả đầu tiên 
            if (picture == null)
            {
                return NotFound();
            }

            return View(picture);
        }

        // GET: Picture/Create
        public IActionResult Create()
        {
            // ViewData["AuthorId"] = new SelectList(_context.Author, "Id","Name");
            return View();
        }

        // POST: Picture/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create([Bind("Id,Name,ImagePath,AuthorId")] Picture picture)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         _context.Add(picture);
        //         await _context.SaveChangesAsync();
        //         return RedirectToAction(nameof(Index));
        //     }
        //     ViewData["AuthorId"] = new SelectList(_context.Author, "Id", "Name", picture.AuthorId);
        //     return View(picture);
        // }
        public async Task<IActionResult> Create(ArtVM vm)
        {
            if (ModelState.IsValid)
            {
                // bên trái : tt của Picture
                // bên phải : vm
                var pic = new Picture // Picture là class Picture
                {
                   
                    Name = vm.Name,
                    ImagePath = vm.ImagePath,
                    AuthorId = vm.AuthorId,
                };
                 
                _context.Picture.Add(pic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }

            ViewData["AuthorId"] = new SelectList(_context.Author, "Id", "Name", vm.AuthorId);
            return View(vm);
        }

        // GET: Picture/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var picture = await _context.Picture.FindAsync(id);
            if (picture == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Author, "Id", "Name", picture.AuthorId);
            return View(picture);
        }

        // POST: Picture/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ImagePath,AuthorId")] Picture picture)
        {
            if (id != picture.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(picture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PictureExists(picture.Id)) // nếu pictureId không tồn tại ? trả về NotFound : throw ném cho hệ thống
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
            ViewData["AuthorId"] = new SelectList(_context.Author, "Id", "Name", picture.AuthorId);
            return View(picture);
        }

        // GET: Picture/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var picture = await _context.Picture
                .Include(p => p.Author)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (picture == null)
            {
                return NotFound();
            }

            return View(picture);
        }

        // POST: Picture/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var picture = await _context.Picture.FindAsync(id);
            if (picture != null)
            {
                _context.Picture.Remove(picture);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PictureExists(int id)
        {
            return _context.Picture.Any(e => e.Id == id);
        }
    }
}
