using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission6_Hogan.Models;

namespace Mission6_Hogan.Controllers;

public class HomeController : Controller
{
    private MovieContext _context;
    
    public HomeController(MovieContext context)
    {
        _context = context;
    }
    
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult AboutJoel()
    {
        return View();
    }

    [HttpGet]
    public IActionResult MovieInput()
    {
        return View();
    }

    [HttpPost]
    public IActionResult MovieInput(Movie movie)
    {
        _context.Movies.Add(movie);
        _context.SaveChanges();
        return View("Confirmation", movie);
    }
    
}