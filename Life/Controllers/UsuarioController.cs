using Microsoft.AspNetCore.Mvc;
using Life.Models;
using Life.Data;

namespace Life.Controllers
{

    namespace GreenLife.Controllers
    {
        public class UsuarioController : Controller
        {
            private readonly LifeDbContext _context;

            public UsuarioController(LifeDbContext context)
            {
                _context = context;
            }

            // Ação para exibir o formulário de cadastro
            public IActionResult Cadastrar()
            {
                return View();
            }

            // Ação para processar o envio do formulário
            [HttpPost]
            public IActionResult Cadastrar(User usuario)
            {
                if (ModelState.IsValid)
                {
                    _context.Usuarios.Add(usuario);  // Adiciona o usuário ao banco de dados
                    _context.SaveChanges();  // Salva as alterações no banco de dados

                    TempData["Mensagem"] = "Usuário cadastrado com sucesso!";
                    return RedirectToAction("Cadastrar");  // Redireciona de volta para o formulário
                }

                return View(usuario);  // Se houver erro de validação, retorna o formulário com os dados preenchidos
            }
        }
    }

}

