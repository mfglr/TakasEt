using Application.ValueObjects;

namespace Application.Entities
{
	public class StoryImage : Image
	{
		public int Index { get; private set; }
		public int StoryId { get; private set; }
		public int DisplayTime {  get; private set; }
		
		public Story Story { get; }
		public IReadOnlyCollection<UserStoryImageLiking> Likes => _likes;
		public IReadOnlyCollection<UserStoryImageViewing> Viewings => _viewings;


		public StoryImage() { }

		public StoryImage(int index, int displayTime, string blobName, string extention, Dimension dimension): base(ContainerName.StoryImage, blobName, extention, dimension)
		{
			Index = index;
			DisplayTime = displayTime;
		}

		public void Update(int index,int displayTime)
		{
			Index = index;
			DisplayTime = displayTime;
		}

		private readonly List<UserStoryImageLiking> _likes = new();
		public void LikeStoryImage(int userId)
		{
			_likes.Add(new UserStoryImageLiking(userId, Id));
		}
		public void DislikeStoryImage(int userId)
		{
			var index = _likes.FindIndex(x => x.UserId == userId && x.StoryImageId == Id);
			_likes.RemoveAt(index);
		}

		private readonly List<UserStoryImageViewing> _viewings = new();
		public void ViewStoryImage(int userId)
		{
			_viewings.Add(new UserStoryImageViewing(userId, Id));
		}
	}
}
