using Microsoft.AspNetCore.Mvc;

namespace MovieList.Controllers
{
    public class DummyPagesController : Controller
    {

        // Default route for Dummy1 (defined in Program.cs).
        public IActionResult Dummy1()
        {
            ViewData["Title"] = "Dummy1 Page";
            return View();
        }

        // Custom route for Dummy2 (defined in Program.cs).
        public IActionResult Dummy2()
        {
            ViewData["Title"] = "Dummy2 Page";
            return View();
        }

        // Attribute routing for Dummy3.
        [Route("CustomAttribute/Dummy3")]
        public IActionResult Dummy3()
        {
            ViewData["Title"] = "Dummy3 Page";
            return View();
        }
    }
}
