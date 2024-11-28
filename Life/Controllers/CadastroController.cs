using Life.Data;
using Life.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LIFE.Controllers
{
    public class CadastroController : Controller
    {
        private readonly AppDbContext _context;

        public CadastroController(AppDbContext context)
        {
            _context = context;
        }

        // Método GET para exibir a página de cadastro
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // Método POST para processar o cadastro
        [HttpPost]
        public IActionResult Register(string email, string password, string confirmPassword)
        {
            // Verificar se os campos obrigatórios foram preenchidos
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                TempData["Error"] = "Preencha todos os campos!";
                return RedirectToAction("Index");
            }

            // Verificar se as senhas são iguais
            if (password != confirmPassword)
            {
                TempData["Error"] = "As senhas não coincidem!";
                return RedirectToAction("Index");
            }

            // Verificar se já existe um usuário com o e-mail fornecido
            if (_context.Users.Any(u => u.Email == email))
            {
                TempData["Error"] = "Este e-mail já está registrado!";
                return RedirectToAction("Index");
            }

            // Adicionar o novo usuário ao banco de dados
            var newUser = new User
            {
                Email = email,
                Password = password // No futuro, considere usar um hash para a senha
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            TempData["Success"] = "Cadastro realizado com sucesso!";
            return RedirectToAction("Index", "Login"); // Redirecionar para a página de login após o cadastro
        }
    }
}
