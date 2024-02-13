using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_EliasBaker.Models;

namespace Mission06_EliasBaker.Controllers
{
    public class HomeController : Controller
    {
        private MoviesContext _context;
        public HomeController(MoviesContext movies) 
        {
            _context = movies;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View("Collection");
        }

        [HttpPost]
        public IActionResult AddMovie(Collection response) 
        {
            _context.movies.Add(response); //add record to DB
            _context.SaveChanges();
            return View("Confirmation", response);
        }
    }
}
