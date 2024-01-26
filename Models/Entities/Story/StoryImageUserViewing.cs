namespace Models.Entities
{
    public class StoryImageUserViewing : CrossEntity
    {
		public override int[] GetKey() => new int[] { StoryImageId, UserId };
        public int StoryImageId { get; private set; }
		public int UserId { get; private set; }

		public StoryImage StoryImage { get; }
		public User User { get; }

        public StoryImageUserViewing(int storyImageId, int userId)
        {
			StoryImageId = storyImageId;
			UserId = userId;
        }
    }
}
