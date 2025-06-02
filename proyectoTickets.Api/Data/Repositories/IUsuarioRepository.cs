using proyectoTickets.Api.Data.Models;
using proyectoTickets.Api.Models;

namespace proyectoTickets.Api.Data.Repositories
{
	public interface IUsuarioRepository:IRepository<Usuario>
	{
		Task<Usuario?> LoginUsuarioAsync(LoginModel model);
	}
}
