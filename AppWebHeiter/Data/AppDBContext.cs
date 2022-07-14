using AppWebHeiter.Models;
using Microsoft.EntityFrameworkCore;

namespace AppWebHeiter.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext (DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<Products> tb_products { get; set; }
    }
}
