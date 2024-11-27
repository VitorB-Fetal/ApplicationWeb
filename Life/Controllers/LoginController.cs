using Microsoft.AspNetCore.Mvc;
using Life.Data;
using Microsoft.EntityFrameworkCore;
namespace Life.Controllers
{
    public class LoginController : Controller
    {
        private readonly LifeDbContext _context;

        public LoginController(LifeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> Login(string cpfCnpj, string senha)
        {
            var user = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.CpfCnpj == cpfCnpj && u.Senha == senha);

            if (user != null)
            {
                
                return RedirectToAction("Login", "Login");
            }

            TempData["Mensagem"] = "Credenciais inválidas!";
            return View();
        }
    }
}
