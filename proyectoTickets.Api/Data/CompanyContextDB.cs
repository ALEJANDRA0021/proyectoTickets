using Microsoft.EntityFrameworkCore;
using proyectoTickets.Api.Data.Models;

namespace proyectoTickets.Api.Data
{
    public class CompanyContextDB :    DbContext
    {
        public CompanyContextDB(DbContextOptions<CompanyContextDB> options)
            : base(options)
        {

        }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<HistorialTicket> HistorialTickets { get; set; }
        public DbSet<ComentarioTicket> ComentariosTickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ComentarioTicket>()
                .HasOne(c => c.Usuario)
                .WithMany()
                .HasForeignKey(c => c.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HistorialTicket>()
                 .HasOne(h => h.Usuario)
                 .WithMany()
                 .HasForeignKey(h => h.UsuarioId)
                 .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
