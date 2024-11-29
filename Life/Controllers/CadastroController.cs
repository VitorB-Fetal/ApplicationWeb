using Life.Data;
using Life.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text.RegularExpressions;

namespace Life.Controllers
{
    public class CadastroController : Controller
    {
        private readonly AppDbContext _context;

        public CadastroController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string email, string password, string confirmPassword)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                TempData["Error"] = "Preencha todos os campos!";
                return RedirectToAction("Index");
            }

            if (password != confirmPassword)
            {
                TempData["Error"] = "As senhas não coincidem!";
                return RedirectToAction("Index");
            }

            // Verificar se a senha contém pelo menos um número e um caractere especial
            if (!Regex.IsMatch(password, @"^(?=.*[0-9])(?=.*[!@#$%^&*(),.?:{ }|<>])"))
            {
                TempData["Error"] = "A senha deve conter pelo menos um número e um caractere especial!";
                return RedirectToAction("Index");
            }

            // Verificar se o email já está registrado
            if (_context.Users.Any(u => u.Email == email))
            {
                TempData["Error"] = "Este e-mail já está registrado!";
                return RedirectToAction("Index");
            }

            var newUser = new User
            {
                Email = email,
                Password = password
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            TempData["Success"] = "Cadastro realizado com sucesso!";
            return RedirectToAction("Index", "Login");
        }
    }
}

