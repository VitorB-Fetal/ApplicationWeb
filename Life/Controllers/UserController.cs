using Life.Data;
using Life.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Life.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Editar()
        {
            // Lógica para obter o email do usuário logado
            var email = HttpContext.Session.GetString("UserEmail");

            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("Index", "Login");
            }

            var user = _context.Users.SingleOrDefault(u => u.Email == email);

            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult Editar(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Update(user);
                _context.SaveChanges();

                TempData["Success"] = "Dados atualizados com sucesso!";
                return RedirectToAction("Editar");
            }

            return View(user);
        }
    }
}
