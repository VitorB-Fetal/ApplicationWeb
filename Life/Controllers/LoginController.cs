using Life.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class LoginController : Controller
{
    private readonly AppDbContext _context;

    public LoginController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Authenticate(string email, string password)
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            TempData["Error"] = "Preencha todos os campos!";
            return RedirectToAction("Index");
        }

        var user = _context.Users.SingleOrDefault(u => u.Email == email && u.Password == password);
        if (user == null)
        {
            TempData["Error"] = "Credenciais inválidas!";
            return RedirectToAction("Index");
        }

        return RedirectToAction("Edit", "User");
    }
}
