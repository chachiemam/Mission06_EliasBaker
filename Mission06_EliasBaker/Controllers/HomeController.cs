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
            ViewBag.categories = _context.categories;
            return View("Collection", new Collection());
        }

        [HttpPost]
        public IActionResult AddMovie(Collection response) 
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response); //add record to DB
                _context.SaveChanges();
                return View("Confirmation", response);
            }
            else
            {
				ViewBag.categories = _context.categories;
				return View("Collection",response);
            }

            
        }

        public IActionResult ReadData() //linq
        {
            var movies = _context.Movies
                .Where(x => x.Rating != "R")
                .OrderBy(x => x.Year).ToList();
                
                

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);
            
            ViewBag.categories = _context.categories;
			
			return View("Collection", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Collection updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();
            return RedirectToAction("ReadData");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            
            
            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Collection c)
        {
            _context.Movies.Remove(c);
            _context.SaveChanges();

            return RedirectToAction("ReadData");
        }
    }
}
