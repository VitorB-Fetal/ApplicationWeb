using Microsoft.EntityFrameworkCore;
using Life.Models;


namespace Life.Data
    {
        public class LifeDbContext : DbContext
        {
            public LifeDbContext(DbContextOptions<LifeDbContext> options) : base(options)
            {
            }

         
            public DbSet<Usuario> Usuarios { get; set; }  
        }
    }
