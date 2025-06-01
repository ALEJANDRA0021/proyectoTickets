using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyectoTickets.Api.Data.Models
{
    public class Categoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Prioridad { get; set; } // "Baja", "Media", "Alta"

        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
