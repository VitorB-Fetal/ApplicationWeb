using Microsoft.EntityFrameworkCore;
using Life.Models;


namespace Life.Data
    {
        public class LifeDbContext : DbContext
        {
        internal object User;

        public LifeDbContext()
        {
        }

        public LifeDbContext(DbContextOptions<LifeDbContext> options) : base(options)
            {
            }

         
            public DbSet<User> Usuarios { get; set; }  
        }
    }
