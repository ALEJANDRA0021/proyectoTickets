using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyectoTickets.Api.Data.Models
{
    public class HistorialTicket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HistorialId { get; set; }
        public required string Descripcion { get; set; }
        public required string Estado { get; set; } // "Abierto", "En Proceso", "Cerrado"
        public DateTime Fecha { get; set; } = DateTime.UtcNow;

        public int TicketId { get; set; }
        [ForeignKey("TicketId")]
        public virtual Ticket? Ticket { get; set; }

        public int UsuarioId { get; set; }
        [ForeignKey("UsuarioId")]
        public virtual Usuario? Usuario { get; set; }
    }
}
