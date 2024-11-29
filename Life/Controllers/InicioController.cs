using Microsoft.AspNetCore.Mvc;
using Life.Models;
using Life.Data;
using System.Linq;

namespace Life.Controllers
{
    public class InicioController : Controller
    {
        private readonly AppDbContext _context;

        public InicioController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Editar(int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
                return NotFound();

            return View("Editar", user); 
        }

        [HttpPost]
        public IActionResult Editar(User model)
        {
            if (!ModelState.IsValid)
                return Json(new { success = false, message = "Dados inválidos." });

            var user = _context.Users.FirstOrDefault(u => u.Id == model.Id);
            if (user == null)
                return Json(new { success = false, message = "Usuário não encontrado." });

            user.Email = model.Email;
            user.Name = model.Name;
            user.Phone = model.Phone;
            user.CPF = model.CPF;

            if (!string.IsNullOrEmpty(model.Password))
            {
                user.Password = model.Password; // Pode-se adicionar um hash de senha aqui
            }

            _context.SaveChanges();

            return Json(new { success = true, message = "Dados atualizados com sucesso!" });
        }
    }
}
