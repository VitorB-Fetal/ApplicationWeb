using Life.Models;
using Life.Data; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Life.Controllers
{
    public class UserController : Controller
    {
        private readonly LifeDbContext _context;

        public UserController(LifeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Nichos = new SelectList(_context.Nichos, "Id", "Nome");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Usuarios.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login", "Login");
            }

            ViewBag.Nichos = new SelectList(_context.Nichos, "Id", "Nome");
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile(int id)
        {
            var user = await _context.Usuarios.FindAsync(id);
            if (user == null) return NotFound();

            ViewBag.Nichos = new SelectList(_context.Nichos, "Id", "Nome");
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Update(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login", "Login");
            }

            ViewBag.Nichos = new SelectList(_context.Nichos, "Id", "Nome");
            return View(user);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Usuarios.FindAsync(id);
            if (user != null)
            {
                _context.Usuarios.Remove(user);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Login", "Login");
        }
    }
}
