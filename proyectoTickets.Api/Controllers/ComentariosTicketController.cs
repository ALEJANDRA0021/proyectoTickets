using Microsoft.AspNetCore.Mvc;
using proyectoTickets.Api.Data.Models;
using proyectoTickets.Api.Data.Repositories;

namespace proyectoTickets.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentariosTicketController : ControllerBase
    {
        private readonly IRepository<ComentarioTicket> _repository;

        public ComentariosTicketController(IRepository<ComentarioTicket> repository)
        {
            _repository = repository;
        }

        // GET: api/ComentariosTicket
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComentarioTicket>>> GetComentarios()
        {
            var comentarios = await _repository.GetAllAsync();
            return Ok(comentarios);
        }

        // GET: api/ComentariosTicket/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComentarioTicket>> GetComentario(int id)
        {
            var comentario = await _repository.GetByIdAsync(id);
            if (comentario == null)
            {
                return NotFound();
            }

            return Ok(comentario);
        }

        // POST: api/ComentariosTicket
        [HttpPost]
        public async Task<ActionResult<ComentarioTicket>> PostComentario(ComentarioTicket comentario)
        {
            comentario.Fecha = DateTime.UtcNow;

            await _repository.AddAsync(comentario);
            await _repository.SaveAsync();

            return CreatedAtAction(nameof(GetComentario), new { id = comentario.ComentarioId }, comentario);
        }

        // PUT: api/ComentariosTicket/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComentario(int id, ComentarioTicket comentario)
        {
            if (id != comentario.ComentarioId)
            {
                return BadRequest();
            }

            var existente = await _repository.GetByIdAsync(id);
            if (existente == null)
            {
                return NotFound();
            }

            existente.Comentario = comentario.Comentario;
            existente.Fecha = DateTime.UtcNow;
            existente.TicketId = comentario.TicketId;
            existente.UsuarioId = comentario.UsuarioId;

            _repository.Update(existente);
            await _repository.SaveAsync();

            return NoContent();
        }

        // DELETE: api/ComentariosTicket/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComentario(int id)
        {
            var comentario = await _repository.GetByIdAsync(id);
            if (comentario == null)
            {
                return NotFound();
            }

            _repository.Remove(comentario);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
