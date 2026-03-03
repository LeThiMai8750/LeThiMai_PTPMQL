using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace webmvc.Controllers;

public class DemoController : Controller
{

    public IActionResult Index()
    {
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


}
