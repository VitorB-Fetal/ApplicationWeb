using Microsoft.AspNetCore.Mvc;

namespace LifeGreen.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult Login(string CpfCnpj, string Senha)
        {
            if (!string.IsNullOrEmpty(CpfCnpj) && !string.IsNullOrEmpty(Senha))
            {
                TempData["Mensagem"] = "Login realizado com sucesso!";
                return RedirectToAction("Login", "Login");
            }

            TempData["Mensagem"] = "CPF/CNPJ ou Senha inv�lidos.";
            return View();
        }
    }
}
