using SharedLibrary.Entities;

namespace ChatMicroservice.Domain.GroupAggregate
{
	public class GroupUser : Entity
	{
		public Guid GroupId { get; private set; }
		public Guid UserId { get; private set; }

		public GroupUser(Guid groupId, Guid userId)
		{
			GroupId = groupId;
			UserId = userId;
		}

	}
}
