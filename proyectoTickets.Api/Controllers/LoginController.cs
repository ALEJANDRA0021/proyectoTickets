using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectoTickets.Api.Data.Models;
using proyectoTickets.Api.Data.Repositories;
using proyectoTickets.Api.Models;

namespace proyectoTickets.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class LoginController : ControllerBase
	{
		private readonly IUsuarioRepository _usuarioRepository;
		 
		public LoginController(IUsuarioRepository usuarioRepository  )
		{
			_usuarioRepository = usuarioRepository;
		}

		[HttpPost]
		public async Task<IActionResult> Login([FromBody] LoginModel request)
		{
			if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
				return BadRequest("Email and password are required");
			
			var user =  await _usuarioRepository.LoginUsuarioAsync(request);

			if (user == null)
				return Unauthorized("Invalid credentials");
			

			var response = new LoginResponse
			{
				Id = user.Id,
				Nombre = user.Nombre,
				Email = user.Email,
				TipoUsuario = user.TipoUsuario
			};

			return Ok(response);
		}
	}

	
}
