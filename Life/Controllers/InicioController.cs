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

        // Ação de GET para carregar os dados do usuário para edição
        [HttpGet]
        public IActionResult Editar(int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
                return NotFound(); // Se o usuário não for encontrado, retorna 404

            return View("Alterar", user); // Retorna a View de edição com os dados do usuário
        }

        // Ação de POST para salvar as alterações
        [HttpPost]
        public IActionResult Editar(User model)
        {
            if (!ModelState.IsValid)
                return Json(new { success = false, message = "Dados inválidos." });

            var user = _context.Users.FirstOrDefault(u => u.Id == model.Id);
            if (user == null)
                return Json(new { success = false, message = "Usuário não encontrado." });

            user.Name = model.Name;
            user.Phone = model.Phone;
            user.CPF = model.CPF;
            user.Email = model.Email;

            if (!string.IsNullOrEmpty(model.Password))
            {
                user.Password = model.Password; // Atualiza a senha se fornecida
            }

            _context.SaveChanges();

            return Json(new { success = true, message = "Dados atualizados com sucesso!" });
        }
    }
}
