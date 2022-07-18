using AppWebHeiter.Models;
using Microsoft.EntityFrameworkCore;

namespace AppWebHeiter.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext (DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        public DbSet<Products> tb_produtos { get; set; } // O nome tb_products sera o nome da tabela

        public DbSet<Login> tb_usuarios { get; set; }
    }
}
