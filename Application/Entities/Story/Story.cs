using Application.ValueObjects;

namespace Application.Entities
{
	public class Story : Entity, IAggregateRoot
	{
		public int UserId { get; private set; }

		public User User { get; }
		public IReadOnlyCollection<StoryImage> StoryImages => _storyImages;
		

		public Story(int userId)
		{
			UserId = userId;
		}


		private readonly List<StoryImage> _storyImages = new();
		public void AddStoryImage(int index,int displayTime,string blobName,string extention,Dimension dimension)
		{
			_storyImages.Add(new StoryImage(index,displayTime, blobName, extention, dimension));
		}
		public void RemoveStoryImage(int id)
		{
			int index = _storyImages.FindIndex(x => x.Id == id);
			_storyImages.RemoveAt(index);
		}

		

	}
}
