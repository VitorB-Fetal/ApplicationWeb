using Life.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Life.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        public IActionResult Authenticate(string email, string password)
        {
            // Verificar se os campos estão preenchidos
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                TempData["Error"] = "Preencha todos os campos!";
                return RedirectToAction("Index");
            }

            // Verificar se as credenciais estão corretas
            var user = _context.Users.SingleOrDefault(u => u.Email == email && u.Password == password);
            if (user == null)
            {
                TempData["Error"] = "Credenciais inválidas!";
                return RedirectToAction("Index");
            }

            // Redirecionar para a Home após autenticação bem-sucedida
            return RedirectToAction("Index", "Home");
        }
    }
}
