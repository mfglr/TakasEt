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

        //for seeds
        public static Role Create(RoleType roleType)
        {
            Role role = new Role(roleType);
            role.SetId();
            return role;
        }
    }
}
