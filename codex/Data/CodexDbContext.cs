using Codex.Models;
using Microsoft.EntityFrameworkCore;

namespace Codex.Data
{
    public class CodexDbContext : DbContext
    {
        public CodexDbContext(DbContextOptions<CodexDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<TipoProducto> TiposProducto { get; set; }
        public DbSet<UsoRecomendado> UsosRecomendados { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Usuario>().HasKey(u => u.ID_Usuario);

            modelBuilder.Entity<Producto>().HasKey(p => p.Id);

        }
    }
}
