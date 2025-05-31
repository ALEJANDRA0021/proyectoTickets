using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyectoTickets.Api.Data.Models
{
    [Table("Empleado")]
    public class Empleado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Usuario { get; set; }
        public string Contrasena { get; set; }

        public string Genero { get; set; }

        public string Correo { get; set; }

        public string Telefono { get; set; }

       
    }
}
