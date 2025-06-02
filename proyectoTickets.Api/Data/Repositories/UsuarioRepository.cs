using Microsoft.EntityFrameworkCore;
using proyectoTickets.Api.Data.Models;
using proyectoTickets.Api.Models;

namespace proyectoTickets.Api.Data.Repositories
{
	public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
	{
		public UsuarioRepository(CompanyContextDB context) : base(context)
		{
		}

		public async Task<Usuario?> LoginUsuarioAsync(LoginModel model)
		{
			var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == model.Email && u.PasswordHash == model.Password);
			if (user == null)
			{
				return null; 
			}
			return user;

		}
	}
}
