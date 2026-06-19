using Bogus;
using Microsoft.EntityFrameworkCore;
using webmvc.Models.Entities;


namespace webmvc.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(ApplicationDbContext context)
        {
      
            

            // ---- 1. SEED DATA CHO BẢNG FACULTY (KHOA) ----
            // Kiểm tra nếu bảng Faculty đã có dữ liệu thì bỏ qua, không add trùng

            // Tạo danh sách Khoa mẫu
            var faculties = new Faculty[]
            {
                new Faculty { FacultyId = "CNTT", FacultyName = "Công nghệ thông tin" },
                new Faculty { FacultyId = "QTKD", FacultyName = "Quản trị kinh doanh" },
                new Faculty { FacultyId = "NNAN", FacultyName = "Ngôn ngữ Anh" }
            };

            await context.Faculties.AddRangeAsync(faculties);
            await context.SaveChangesAsync(); // Lưu trước để đảm bảo khóa chính Khoa tồn tại


            // ---- 2. SEED DATA CHO BẢNG STUDENT (SINH VIÊN) ----

            var faker = new Faker<Student>()
                // Sinh mã sinh viên ngẫu nhiên đảm bảo đủ độ dài (ví dụ: SV20261001)
                .RuleFor(s => s.StudentCode, f => $"SV{f.Random.Number(100000, 999999)}")
                
                // Sinh tên đầy đủ bằng ngôn ngữ tiếng Anh (hoặc tiếng Việt tùy ý)
                .RuleFor(s => s.FullName, f => f.Name.FullName())
                
                // Chọn ngẫu nhiên 1 trong các mã Khoa đã tạo ở trên để không bị lỗi khóa ngoại
                .RuleFor(s => s.FacultyId, f => f.PickRandom(faculties).FacultyId);
            
            // Khi databasse có dữ liệu rồi thì  xóa sạch và sinh mới bản ghi

            context.Books.RemoveRange(context.Books);

            context.SaveChanges();



            // Sinh ngẫu nhiên 200 bản ghi sinh viên
            var fakeStudents = faker.Generate(200);

            // Đảm bảo không bị trùng lặp khóa chính (StudentCode) ngẫu nhiên trong tập sinh ra
            var distinctStudents = fakeStudents.GroupBy(s => s.StudentCode)
                                               .Select(g => g.First())
                                               .ToList();

            // 4. LƯU VÀO DATABASE
            await context.Students.AddRangeAsync(distinctStudents);
            await context.SaveChangesAsync();
        }
    }
}