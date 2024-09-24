using Ch04MovieList.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieList.Models;

namespace MovieList.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private MovieContext context { get; set; }
        public HomeController(MovieContext ctx) => context = ctx;
        public IActionResult Index()
        {
            ViewData["Title"] = "Movie List";
            var movies = context.Movies.Include(m => m.Genre).OrderBy(m => m.Name).ToList(); 
            return View(movies);

        }
    }
}