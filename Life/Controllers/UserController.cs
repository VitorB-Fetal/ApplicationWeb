using Life.Data;
using Life.Models;
using Microsoft.AspNetCore.Mvc;
namespace Life.Controllers
{
    public class UserController : Controller
    {
        private readonly LifeDbContext _context = new();
        public ActionResult Create()
        {
            ViewBag.Nichos = new[] { "Mercado", "Mercadinho", "Mercearia", "Hortifruti","Fazenda" };
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Usuarios.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Login", "Login");
            }
            ViewBag.Nichos = new[] { "Mercado", "Mercadinho", "Mercearia", "Hortifruti","Fazenda" };
            return View(user);
        }
    }
}