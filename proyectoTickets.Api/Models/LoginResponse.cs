﻿namespace proyectoTickets.Api.Models
{
	public class LoginResponse
	{
		public int Id { get; set; }
		public string Nombre { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string TipoUsuario { get; set; } = string.Empty;
	}
}
