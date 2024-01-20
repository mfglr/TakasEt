using Newtonsoft.Json;

namespace Application.Entities
{
	public class UserRole : Entity
	{
        public int UserId { get; private set; }
        public User User { get; }
		public int RoleId { get; private set; }
        public Role Role { get; }

        public UserRole(int userId, int roleId)
		{
			UserId = userId;
			RoleId = roleId;
		}
		[JsonConstructor]
		public UserRole(int id, int userId, int roleId,DateTime createdDate)
		{
			Id = id;
			UserId = userId;
			RoleId = roleId;
			CreatedDate = createdDate;
		}


	}
}
