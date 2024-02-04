using SharedLibrary.Entities;

namespace ChatMicroservice.Domain.GroupAggregate
{
	public class GroupUser : Entity
	{
		public Guid UserId { get; private set; }

		public GroupUser(Guid userId)
		{
			UserId = userId;
		}

	}
}
