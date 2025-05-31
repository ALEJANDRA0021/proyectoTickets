using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyectoTickets.Api.Data.Models
{
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TicketId { get; set; }

        [Required]
        public string Titulo { get; set; } = string.Empty;

        [Required]
        public string Descripcion { get; set; } = string.Empty;

        [Required]
        public string Estado { get; set; } = "Abierto"; // "Abierto", "En Proceso", "Cerrado"

        [Required]
        public string Prioridad { get; set; } = "Media"; // "Baja", "Media", "Alta"

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        public DateTime FechaActualizacion { get; set; } = DateTime.UtcNow;

        // Usuario que creó el ticket
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual Usuario? Cliente { get; set; }

        // Categoría del ticket
        public int CategoriaId { get; set; }

        [ForeignKey("CategoriaId")]
        public virtual Categoria? Categoria { get; set; }

        // Empleado asignado (puede ser null al principio)
        public int? EmpleadoAsignadoId { get; set; }

        [ForeignKey("EmpleadoAsignadoId")]
        public virtual Usuario? EmpleadoAsignado { get; set; }

        // Historial del ticket
        public virtual ICollection<HistorialTicket> Historial { get; set; } = new List<HistorialTicket>();

        // Comentarios del ticket
        public virtual ICollection<ComentarioTicket> Comentarios { get; set; } = new List<ComentarioTicket>();
    }
}
