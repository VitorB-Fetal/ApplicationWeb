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

            
            public IActionResult Cadastrar()
            {
                return View();
            }

           
            [HttpPost]
            public IActionResult Cadastrar(User usuario)
            {
                if (ModelState.IsValid)
                {
                    _context.Usuarios.Add(usuario);  
                    _context.SaveChanges();  

                    TempData["Mensagem"] = "Usuário cadastrado com sucesso!";
                    return RedirectToAction("Cadastrar");  
                }

                return View(usuario);  
            }
        }
    }

}

