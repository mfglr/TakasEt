using Newtonsoft.Json;

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
		[JsonConstructor]
		public UserRole(Guid id, Guid userId, Guid roleId,DateTime createdDate)
		{
			Id = id;
			UserId = userId;
			RoleId = roleId;
			CreatedDate = createdDate;
		}


	}
}
