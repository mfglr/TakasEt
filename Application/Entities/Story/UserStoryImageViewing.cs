namespace Application.Entities
{
	public class UserStoryImageViewing : CrossEntity
	{
		public int UserId { get; private set; }
		public int StoryImageId { get; private set; }

		public User User { get; }
		public StoryImage StoryImage { get; }

		public override int[] GetKey()
		{
			return new int[] { UserId, StoryImageId };
		}

		public UserStoryImageViewing(int userId,int storyImageId)
		{
			UserId = userId;
			StoryImageId = storyImageId;
		}
	}
}
