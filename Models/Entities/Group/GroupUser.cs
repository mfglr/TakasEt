namespace Models.Entities
{
	public class GroupUser : CrossEntity<Group,User>
	{
		public override int[] GetKey() => new int[] { GroupId, UserId };
		public int GroupId { get; private set; }
		public int UserId { get; private set; }

		public Group Group { get; }
		public User User { get; }

		public GroupUser(int groupId, int userId)
		{
			GroupId = groupId;
			UserId = userId;
		}

	}
}
