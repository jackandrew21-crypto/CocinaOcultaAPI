using Microsoft.EntityFrameworkCore;

namespace CocinaOcultaAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Cedula)
                .IsUnique(); // Para que la cédula no se repita

            base.OnModelCreating(modelBuilder);
        }
    }
}


