using SharedLibrary.Entities;

namespace ChatMicroservice.Domain.GroupAggregate
{
	public class GroupUser : Entity
	{
		public int UserId { get; private set; }
		public UserRole Role { get; private set; }

		public GroupUser(int userId)
		{
			UserId = userId;
		}

		public void MakeAdmin() => Role = UserRole.Admin;
		public void MakeUser() => Role = UserRole.User;
	}
}
