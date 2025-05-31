using Microsoft.AspNetCore.Mvc;
using proyectoTickets.Api.Data.Models;
using proyectoTickets.Api.Data.Repositories;

namespace proyectoTickets.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly IRepository<Ticket> _repository;

        public TicketsController(IRepository<Ticket> repository)
        {
            _repository = repository;
        }

        // GET: api/Tickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets()
        {
            var tickets = await _repository.GetAllAsync();
            return Ok(tickets);
        }

        // GET: api/Tickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicket(int id)
        {
            var ticket = await _repository.GetByIdAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }

        // POST: api/Tickets
        [HttpPost]
        public async Task<ActionResult<Ticket>> PostTicket(Ticket ticket)
        {
            ticket.FechaCreacion = DateTime.UtcNow;
            ticket.FechaActualizacion = DateTime.UtcNow;

            await _repository.AddAsync(ticket);
            await _repository.SaveAsync();

            return CreatedAtAction(nameof(GetTicket), new { id = ticket.TicketId }, ticket);
        }

        // PUT: api/Tickets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicket(int id, Ticket ticket)
        {
            if (id != ticket.TicketId)
            {
                return BadRequest();
            }

            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
            {
                return NotFound();
            }

            existing.Titulo = ticket.Titulo;
            existing.Descripcion = ticket.Descripcion;
            existing.Estado = ticket.Estado;
            existing.Prioridad = ticket.Prioridad;
            existing.FechaActualizacion = DateTime.UtcNow;
            existing.UsuarioId = ticket.UsuarioId;
            existing.CategoriaId = ticket.CategoriaId;
            existing.EmpleadoAsignadoId = ticket.EmpleadoAsignadoId;

            _repository.Update(existing);
            await _repository.SaveAsync();

            return NoContent();
        }

        // DELETE: api/Tickets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var ticket = await _repository.GetByIdAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            _repository.Remove(ticket);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
