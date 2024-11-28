using Microsoft.AspNetCore.Mvc;

namespace Life.Controllers
{

    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Edit() => View();
    }

}
