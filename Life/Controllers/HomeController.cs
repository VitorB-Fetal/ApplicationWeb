using Microsoft.AspNetCore.Mvc;

namespace Life.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
