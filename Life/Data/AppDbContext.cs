using Life.Models;
using Microsoft.EntityFrameworkCore;

namespace Life.Data
{
    public class AppDbContext : DbContext  // Certifique-se de que a classe é chamada AppDbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
