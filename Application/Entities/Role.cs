using Application.ValueObjects;

namespace Application.Entities
{
	public class Role : Entity
	{
        public RoleType RoleType { get; private set; }
        public IReadOnlyCollection<User> Users { get; private set; }
        
		public Role() { }
		
		public Role(RoleType roleType) { 
			RoleType = roleType;
		}

		public static Role Create(string name,int index)
		{
			var role = new Role();
			role.SetId();
			return role;
		}


    }
}
