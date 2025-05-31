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
    }
}
