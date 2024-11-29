using Life.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
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
            return View();
        }

        [HttpPost]
        public IActionResult Authenticate(string email, string password)
        {
            // Verificar se os campos estão vazios
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                TempData["Error"] = "Preencha todos os campos!";
                return RedirectToAction("Index");
            }

            // Verificar se o email está correto
            var user = _context.Users.SingleOrDefault(u => u.Email == email);
            if (user == null)
            {
                TempData["Error"] = "Email incorreto!";
                return RedirectToAction("Index");
            }

            // Verificar se a senha está correta
            if (user.Password != password)
            {
                TempData["Error"] = "Senha incorreta!";
                return RedirectToAction("Index");
            }

            // Armazenar o ID do usuário na sessão
            HttpContext.Session.SetInt32("UserId", user.Id);

            // Se as credenciais estiverem corretas, redireciona para a página de edição
            TempData["Success"] = "Acesso realizado com sucesso!";
            return RedirectToAction("Editar", "Alterar"); // Redireciona para o controlador Alterar, ação Editar
        }
    }
}
