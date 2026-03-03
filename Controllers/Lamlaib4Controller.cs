using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Formats.Tar;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using webmvc.Models.Entities;

namespace webmvc.Controllers
{
    
    public class Lamlaib4Controller : Controller
    {
        public IActionResult Index() //mặc định
        {
            return View();
        }
        // định tuyến
        public IActionResult Form()
        {
            return View();
        }
        // lấy dữ liệu 
        [HttpPost]
        public IActionResult Form(string Ten , int Tuoi)
        {
            ViewBag.Ten = Ten;
            ViewBag.Tuoi = Tuoi;
            return View();
        }
        public IActionResult Form1()
        {
            return View();
        }
        [HttpPost]
        // model binding
        public IActionResult Form1(Student std)
        {
            ViewBag.Thongbao = "Họ tên: " + std.FullName + "   Tuổi: " + std.StudentCode; 
 
            return View();
        }
    }
}