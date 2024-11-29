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

        // GET: User/Editar
        [HttpGet]
        public IActionResult Editar(int id)
        {
            // Verificar se o usuário está autenticado
            if (!User.Identity.IsAuthenticated)
            {
                TempData["Error"] = "Por favor, faça login para acessar esta página.";
                return RedirectToAction("Index", "Login");  // Redireciona para a página de login
            }

            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound();

            return View(user); // Passa o modelo para a View
        }

        // POST: User/Editar
        [HttpPost]
        public IActionResult Editar(User user)
        {
            // Verificar se o usuário está autenticado
            if (!User.Identity.IsAuthenticated)
            {
                TempData["Error"] = "Por favor, faça login para acessar esta página.";
                return RedirectToAction("Index", "Login");  // Redireciona para a página de login
            }

            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Dados inválidos. Por favor, revise os campos.";
                return View(user);
            }

            var userInDb = _context.Users.FirstOrDefault(u => u.Id == user.Id);
            if (userInDb == null)
                return NotFound();

            userInDb.Name = user.Name;
            userInDb.Phone = user.Phone;
            userInDb.Email = user.Email;
            userInDb.CPF = user.CPF;

            if (!string.IsNullOrEmpty(user.Password))
                userInDb.Password = user.Password; // Atualiza a senha apenas se fornecida

            _context.SaveChanges();

            TempData["Success"] = "Dados atualizados com sucesso!";
            return RedirectToAction("Index", "Home");
        }
    }
}
