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
        ViewBag.Categories = _context.Categories
            .OrderBy(m => m.CategoryName)
            .ToList();
        return View(new Movie());
    }

    [HttpPost]
    public IActionResult MovieInput(Movie movie)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            
            return View("Confirmation", movie);
        }
        else
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(m => m.CategoryName)
                .ToList();
            return View(movie);
        }
        
    }

    [HttpGet]
    public IActionResult ViewMovies()
    {
        var movies = _context.Movies
            .OrderBy(m => m.MovieId).ToList();
        return View(movies);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        Movie movie = _context.Movies
            .Single(m => m.MovieId == id);

        ViewBag.Categories = _context.Categories
            .OrderBy(m => m.CategoryName)
            .ToList();
        
        return View("MovieInput", movie);
    }
    
    [HttpGet]
    public IActionResult Delete(int id)
    {
        Movie movieRemove = _context.Movies
            .Single( m => m.MovieId == id);
        
        return View(movieRemove);
    }

    [HttpPost]
    public IActionResult Edit(Movie movie)
    {
        _context.Update(movie);
        _context.SaveChanges();

        return RedirectToAction("ViewMovies");
    }

    [HttpPost]
    public IActionResult Delete(Movie deleteMovie)
    {
        _context.Movies.Remove(deleteMovie);
        _context.SaveChanges();
        
        return RedirectToAction("ViewMovies");
    }
    
}