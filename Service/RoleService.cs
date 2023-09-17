using Application.Entities;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;

namespace Service
{
	public class RoleService : IRoleService
	{

		public RoleService(IRepository<Role> roles)
		{
			setRoles(roles.DbSet.ToList());
		}

		private void setRoles(IEnumerable<Role> roles)
		{
			foreach (var prop in typeof(IRoleService).GetProperties())
				prop.SetValue(this,roles.First(role => role.Name.ToLower() == prop.Name.ToLower()));
		}

		public Role User { get; set; } 
		public Role Admin { get; set; }
		public Role Client { get; set; }
	}
}
