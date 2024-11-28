using Life.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace Life.Data
{
    
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }

}
