using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Bogus.DataSets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SQLitePCL;

namespace webmvc.Controllers;

public class DemoController : Controller
{
    // static List<string> images = new();

    public IActionResult Index()
    {
         ViewBag.Message = "Xin chào bạn Mai";
        return View();
    }
    // sử dụng viewbag để gửi dữ liệu từ controller về view
    public IActionResult Vidu()
    {
        ViewBag.message = "LE THI MAI - 2221050479";
        return View();
    }

    //mở form
    public IActionResult Form()
    {
        
        return View();
    }
    // nhận dữ liệu (POST) và gửi  dữ liệu đến view
    [HttpPost]
    public IActionResult Form(string FullName )
    {
        ViewBag.Ten = "Xin chào " + FullName;
        return View();
    }
    // Mở Fom - Khi tạo Form xong
    public IActionResult Fom()
    {
       
        return View();
    }
    //1  Nhận dữ liệu

    [HttpPost]
     public IActionResult Fom(string fullname, IFormFile tacpham)
    {
        //2  kiểm tra dữ liệu ModeState = isvalid

        
        if ( tacpham != null)
        {   // Thư mục chứa  ảnh 
            var folder = Path.Combine( Directory.GetCurrentDirectory(), "wwwroot/images" );
            
            // tên file
            var fileName = tacpham.FileName;
            // đường dẫn lưu ảnh 
            var path = Path.Combine(folder,fileName);
             // lưu file
        using(var stream =
            new FileStream(
                path,
                FileMode.Create
            ))
        {
            // tạo thành bản sao
            tacpham.CopyTo(stream);
        }
        
        ViewBag.Images = "/images/" + fileName;
       
    }


        // hiển thị dl
        ViewBag.Name = fullname;
        // ViewBag.Images = tacpham;

         return View();
     }


}
