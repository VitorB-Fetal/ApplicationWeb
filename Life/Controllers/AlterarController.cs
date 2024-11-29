using Life.Data;
using Life.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; // Para usar o Session
using System.Linq;

namespace Life.Controllers
{
    public class AlterarController : Controller
    {
        private readonly AppDbContext _context;

        public AlterarController(AppDbContext context)
        {
            _context = context;
        }

        // Ação para carregar a página de alteração
        [HttpGet]
        public IActionResult Editar()
        {
            // Pega o ID do usuário logado da sessão
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                TempData["Error"] = "Você precisa estar logado para alterar os dados.";
                return RedirectToAction("Index", "Login");
            }

            var user = _context.Users.SingleOrDefault(u => u.Id == userId);
            if (user == null)
            {
                TempData["Error"] = "Usuário não encontrado!";
                return RedirectToAction("Index", "Home"); // Redireciona para a Home caso o usuário não seja encontrado
            }

            return View(user);
        }

        // Ação para salvar as alterações
        [HttpPost]
        public IActionResult Editar(User updatedUser)
        {
            if (ModelState.IsValid)
            {
                var userId = HttpContext.Session.GetInt32("UserId");

                if (userId == null)
                {
                    TempData["Error"] = "Você precisa estar logado para alterar os dados.";
                    return RedirectToAction("Index", "Login");
                }

                var user = _context.Users.SingleOrDefault(u => u.Id == userId);
                if (user == null)
                {
                    TempData["Error"] = "Usuário não encontrado!";
                    return RedirectToAction("Index", "Home"); // Redireciona para a Home caso o usuário não seja encontrado
                }

                // Atualiza os dados do usuário
                user.Name = updatedUser.Name;
                user.Phone = updatedUser.Phone;
                user.CPF = updatedUser.CPF;

                // Salva as mudanças no banco de dados
                _context.SaveChanges();

                TempData["Success"] = "Dados atualizados com sucesso!";
                return RedirectToAction("Editar"); // Redireciona para a página de edição novamente
            }

            return View(updatedUser);
        }
    }
}
