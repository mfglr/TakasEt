using SharedLibrary.Entities;

namespace ChatMicroservice.Domain.GroupAggregate
{
	public class GroupUser : Entity
	{
		public Guid UserId { get; private set; }
		public UserRole Role { get; private set; }

		public GroupUser(Guid userId)
		{
			UserId = userId;
		}

		public void MakeAdmin() => Role = UserRole.Admin;
		public void MakeUser() => Role = UserRole.User;
	}
}
