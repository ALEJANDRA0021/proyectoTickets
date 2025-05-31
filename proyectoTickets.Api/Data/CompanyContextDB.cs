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

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Cliente)
                .WithMany() // or .WithMany(u => u.TicketsCreados) if inverse is needed
                .HasForeignKey(t => t.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete if needed

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.EmpleadoAsignado)
                .WithMany() // or .WithMany(u => u.TicketsAsignados)
                .HasForeignKey(t => t.EmpleadoAsignadoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
