using Models.ValueObjects;

namespace Models.Entities
{
    public class StoryImage : Image, ILikeable<StoryImageUserLiking>, IViewable<StoryImageUserViewing>
    {
        public int Index { get; private set; }
        public int StoryId { get; private set; }
        public int DisplayTime { get; private set; }

        public Story Story { get; }

        public StoryImage() { }

        public StoryImage(int index, int displayTime, string blobName, string extention, Dimension dimension) : base(ContainerName.StoryImage, blobName, extention, dimension)
        {
            Index = index;
            DisplayTime = displayTime;
        }

        public void Update(int index, int displayTime)
        {
            Index = index;
            DisplayTime = displayTime;
        }

		//IViewble
		public IReadOnlyCollection<StoryImageUserViewing> UsersWhoViewed => _usersWhoViewed;
		private readonly List<StoryImageUserViewing> _usersWhoViewed = new();
        public void View(int userId)
        {
			_usersWhoViewed.Add(new StoryImageUserViewing(Id, userId));
        }
        public bool IsViewed(int userId)
        {
            return _usersWhoViewed.Any(x => x.UserId == userId);
        }

		//ILikeable
		public IReadOnlyCollection<StoryImageUserLiking> UsersWhoLiked => _usersWhoLiked;
		private readonly List<StoryImageUserLiking> _usersWhoLiked = new();
        public void Like(int userId)
        {
			_usersWhoLiked.Add(new StoryImageUserLiking(Id, userId));
        }
        public void Dislike(int userId)
        {
            var index = _usersWhoLiked.FindIndex(x => x.UserId == userId);
			_usersWhoLiked.RemoveAt(index);
        }
        public bool IsLiked(int userId)
        {
            return _usersWhoLiked.Any(x => x.UserId == userId);
        }

    }
}
