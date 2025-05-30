using codex.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace codex.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Computadora> Computadoras { get; set; }
        public DbSet<Pregunta> Preguntas { get; set; }
        public DbSet<Respuesta> Respuestas { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Respuesta>()
                .HasOne(r => r.Pregunta)
                .WithMany(p => p.Respuestas)
                .HasForeignKey(r => r.PreguntaId);

            builder.Entity<Computadora>()
                .Property(c => c.Precio)
                .HasPrecision(18, 2); // <- Se agrego esto, para que tenga precisión: hasta 18 dígitos, 2 decimales
        }

    }
}
