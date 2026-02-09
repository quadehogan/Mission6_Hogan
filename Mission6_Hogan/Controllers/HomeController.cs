using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission6_Hogan.Models;

namespace Mission6_Hogan.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    
    
}