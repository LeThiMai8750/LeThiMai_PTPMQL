using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System;
using System.Linq;
using System.Threading.Tasks;
using webmvc.Data;
using webmvc.Models.Entities;
using webmvc.Models.Process;
using webmvc.Models.ViewModels;

namespace webmvc.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ExcelProcess _excelProcess = new ExcelProcess();

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Index (Tải giao diện chính)
        public async Task<IActionResult> Index()
        {
            ViewBag.Faculties = await _context.Faculties.ToListAsync();
            return View();
        }

        // READ: Trả về Partial View bảng sinh viên có phân trang (Chuẩn AJAX)
        [HttpGet]
        public async Task<IActionResult> GetStudentTable(int page = 1, int pageSize = 10)
        {
            

            // 1. Lập kế hoạch: Lấy dữ liệu không tracking và sắp xếp mã mới nằm trên cùng
            var query = _context.Students
                .AsNoTracking() 
                .OrderByDescending(x => x.StudentCode);

            // 2. Đếm tổng số sinh viên (Chạy rất nhanh vì không ôm kèm Faculty)
            var totalItems = await query.CountAsync();

            // 3. Lấy dữ liệu phân trang thực tế
            var students = await query
                .Include(s => s.Faculty) // Chỉ Include ở bước lấy dữ liệu hiển thị
                .Skip((page - 1) * pageSize) 
                .Take(pageSize) 
                .ToListAsync();
            
            // 4. Đóng gói thành phẩm đúng theo cấu trúc Model.Items của View
            var result = new PagedResult<Student>
            {
                Items = students,
                CurrentPage = page,
                PageSize = pageSize,
                TotalItems = totalItems,
            };

            return PartialView("_StudentTable", result);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            // BẮT BUỘC phải có dòng này ở đây để Popup có dữ liệu hiển thị
            ViewBag.Faculties = await _context.Faculties.ToListAsync();
            
            // Nếu bạn dùng PartialView cho Popup
            return PartialView("_Create"); 
            
  
        }
        [HttpPost]

        // 2. CREATE: Thêm mới sinh viên
        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_Create", student);
            }
                await _context.Students.AddAsync(student);
                await _context.SaveChangesAsync(); 
                return Json(new { success = true });
            

        }

        // 3. UPDATE: Chỉnh sửa thông tin sinh viên
        [HttpPost]
        public async Task<IActionResult> Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Update(student);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Cập nhật thông tin thành công!" });
            }
            
            var errors = string.Join(" ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
            return Json(new { success = false, message = errors });
        }

        // 4. DELETE: Xóa sinh viên
        [HttpPost]
        public async Task<IActionResult> Delete(string code)
        {
            var student = await _context.Students.FindAsync(code);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Xóa sinh viên thành công!" });
            }
            return Json(new { success = false, message = "Không tìm thấy sinh viên yêu cầu!" });
        }

        // GET: Upload form
        public IActionResult Upload()
        {
            return View();
        }

        // POST: Xử lý Upload file Excel dữ liệu sinh viên
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                ModelState.AddModelError("", "Vui lòng chọn một file Excel hợp lệ!");
                return View();
            }

            string fileExtension = Path.GetExtension(file.FileName).ToLower();
            if (fileExtension != ".xls" && fileExtension != ".xlsx")
            {
                ModelState.AddModelError("", "Định dạng file không hợp lệ! Vui lòng chọn file (.xls) hoặc (.xlsx)");
                return View();
            }

            // Đổi cách đặt tên file bằng định dạng thời gian chuẩn yyyyMMdd_HHmmss không chứa dấu cấm
            var fileName = DateTime.Now.ToString("yyyyMMdd_HHmmss") + fileExtension;
            
            // Đảm bảo thư mục lưu trữ tồn tại
            var uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", "Excels");
            if (!Directory.Exists(uploadDir))
            {
                Directory.CreateDirectory(uploadDir);
            }
            
            var filePath = Path.Combine(uploadDir, fileName);

            // Bước A: Ghi file xuống Server và đóng stream ngay lập tức khi ra khỏi khối using
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Bước B: Đọc dữ liệu sau khi file đã được giải phóng hoàn toàn
            try
            {
                var dt = _excelProcess.ReadExcelToDataTable(filePath);
                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    var ps = new Student
                    {
                        StudentCode = dt.Rows[i][0].ToString()!,
                        FullName = dt.Rows[i][1].ToString()!,
                        FacultyId = dt.Rows[i][2].ToString()!
                    };

                    // Kiểm tra trùng mã trước khi add từ Excel để tránh sập DB giữa chừng
                    if (!_context.Students.Any(s => s.StudentCode == ps.StudentCode))
                    {
                        _context.Students.Add(ps);
                    }
                }
                
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Lỗi trong quá trình đọc file: " + ex.Message);
            }

            return View();
        }

        // API kiểm tra nhanh thông tin
        [HttpGet]
        public async Task<Student?> GetByCode(string code)
        {
            return await _context.Students.AsNoTracking().FirstOrDefaultAsync(s => s.StudentCode == code);
        }
    }
}