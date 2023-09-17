using Application.Entities;

namespace Application.Interfaces.Services
{
	public interface IRoleService
	{
		Role User { get; set; }
		Role Admin { get; set; }
		Role Client { get; set; }
	}
}
