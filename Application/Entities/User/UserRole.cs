namespace Application.Entities
{
	public class UserRole : CrossEntity
	{
        public int UserId { get; private set; }
		public int RoleId { get; private set; }

		public User User { get; }
		public Role Role { get; }

		public override int[] GetKey()
		{
			return new int[] { RoleId, UserId };
		}

		public UserRole(int userId, int roleId)
		{
			UserId = userId;
			RoleId = roleId;
		}
		
	}
}
