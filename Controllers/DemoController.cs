using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using webmvc.Models;

namespace webmvc.Controllers;

public class DemoController : Controller
{
    public IActionResult Index()
    {
       return View();
    }


}
