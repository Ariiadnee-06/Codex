using Microsoft.EntityFrameworkCore;
using Codex.Models;

namespace Codex.Data
{
    public class CodexDbContext : DbContext
    {
        public CodexDbContext(DbContextOptions<CodexDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasKey(u => u.ID_Usuario);
        }
    }
}
