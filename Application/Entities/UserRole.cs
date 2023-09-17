namespace Application.Entities
{
	public class UserRole : Entity
	{
        public Guid UserId { get; private set; }
        public User User { get; }
		public Guid RoleId { get; private set; }
        public Role Role { get; }

        public UserRole(Guid userId, Guid roleId)
		{
			UserId = userId;
			RoleId = roleId;
		}
	}
}
