using Life.Models;
using Life.Data;  // Adiciona a referência ao seu AppDbContext
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Life.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context; // Usando AppDbContext

        public HomeController(AppDbContext context)
        {
            _context = context; // Inicializa o contexto
        }

        // Ação GET para exibir a página de edição de dados do usuário
        [HttpGet]
        public IActionResult Alterar(int id)
        {
            // Busca o usuário no banco de dados com base no 'id'
            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound(); // Se o usuário não for encontrado, retorna NotFound
            }

            return View(user); // Retorna a view com o objeto User encontrado
        }

        // Ação POST para salvar as alterações dos dados do usuário
        [HttpPost]
        public IActionResult Alterar(User user)
        {
            if (ModelState.IsValid)
            {
                // Atualiza os dados do usuário no banco de dados
                _context.Users.Update(user);
                _context.SaveChanges(); // Salva as mudanças no banco de dados

                return RedirectToAction("Index", "Home"); // Redireciona para a página inicial após salvar
            }

            return View(user); // Se houver erro de validação, retorna a view para correções
        }
    }
}
