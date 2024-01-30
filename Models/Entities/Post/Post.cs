using Models.Extentions;
using Models.ValueObjects;

namespace Models.Entities
{
	public class Post : Entity, IAggregateRoot, ILikeable<PostUserLiking>, IViewable<PostUserViewing>, IExplorable<PostUserExploring>
    {
        public string Title { get; private set; }
        public string NormalizedTitle { get; private set; }
        public string Content { get; private set; }
        public int NumberOfImages { get; private set; }
        public int UserId { get; private set; }
        public int CategoryId { get; private set; }

        public User User { get; }
        public Category Category { get; }
        public IReadOnlyCollection<Swapping> RequesterSwappings { get; }
        public IReadOnlyCollection<Swapping> RequestedSwappings { get; }
        public IReadOnlyCollection<Comment> Comments { get; }
        public IReadOnlyCollection<Requesting> RequestedPosts => _requestedPosts;
        public IReadOnlyCollection<Requesting> RequesterPosts => _requesterPosts;
        public IReadOnlyCollection<PostTag> Tags { get; }

        
        private readonly List<Requesting> _requestedPosts = new();
        private readonly List<Requesting> _requesterPosts = new();
        private readonly List<Swapping> _requesterSwappings = new();


        public Post(int userId, string title, string content, int categoryId, int numberOfImages)
        {
            UserId = userId;
            CategoryId = categoryId;
            Title = title;
            NormalizedTitle = title.CustomNormalize();
            Content = content;
            NumberOfImages = numberOfImages;
        }

        public void Update(string title)
        {
            Title = title;
			NormalizedTitle = title.CustomNormalize();
		}

		//post images
		public IReadOnlyCollection<PostImage> PostImages => _images;
		private readonly List<PostImage> _images = new();
		public void AddImage(string blobName, string extention, int index, Dimension dimension)
        {
            _images.Add(new PostImage(blobName, extention, index, dimension));
            NumberOfImages++;
        }
        public void RemoveImage(int postImageId)
        {
            var image = _images.First(x => x.Id == postImageId);
            image.Remove();
            NumberOfImages--;
        }
        public void DeleteImage(int postImageId)
        {
            var index = _images.FindIndex(x => x.Id == postImageId);
            _images.RemoveAt(index);
            NumberOfImages--;
        }

		//ILikeable
		public IReadOnlyCollection<PostUserViewing> UsersWhoViewed => _usersWhoViewed;
		private readonly List<PostUserLiking> _usersWhoLiked = new();
        public void Like(int userId)
        {
            _usersWhoLiked.Add(new PostUserLiking(userId, Id));
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

		//IViewable
		public IReadOnlyCollection<PostUserLiking> UsersWhoLiked => _usersWhoLiked;
		private readonly List<PostUserViewing> _usersWhoViewed = new();
		public void View(int userId)
		{
			_usersWhoViewed.Add(new PostUserViewing(userId, Id));
		}
		public bool IsViewed(int userId)
		{
			return _usersWhoViewed.Any(x => x.UserId == userId);
		}

		//IExplorable
		public IReadOnlyCollection<PostUserExploring> UsersWhoExplored => _usersWhoExplored;
		private readonly List<PostUserExploring> _usersWhoExplored = new();
		public void Explore(int userId)
        {
			_usersWhoExplored.Add(new PostUserExploring(userId, Id));
        }
        public bool IsExplored(int userId)
        {
            return _usersWhoExplored.Any(x => x.UserId == userId);
        }

		//swapping
		public void CreateSwapping(int requestedPostId)
        {
            _requesterSwappings.Add(new Swapping(Id, requestedPostId));
        }


        //requesting
        public void MakeRequest(int requestedPostId)
        {
            _requesterPosts.Add(new Requesting(Id, requestedPostId));
        }

		
    }
}
