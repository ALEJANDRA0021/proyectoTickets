using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace proyectoTickets.Api.Data.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuarioId { get; set; }
        public required string Nombre { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public required string TipoUsuario { get; set; } // "empleado" o "cliente"
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        public virtual ICollection<Ticket> TicketsCreados { get; set; } = new List<Ticket>();
        public virtual ICollection<Ticket> TicketsAsignados { get; set; } = new List<Ticket>();
        public virtual ICollection<HistorialTicket> Historiales { get; set; } = new List<HistorialTicket>();
        public virtual ICollection<ComentarioTicket> Comentarios { get; set; } = new List<ComentarioTicket>();
    }
}
