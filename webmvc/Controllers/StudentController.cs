using System.Threading.Tasks.Dataflow;
using Microsoft.AspNetCore.Mvc;
using webmvc.Models.Entities;
namespace webmvc.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Student std)
        {   
            ViewBag.Thongbao = "Họ tên: " + std.FullName + " Mã sinh viên: " + std.StudentCode;
            return View();
        }
    }
}