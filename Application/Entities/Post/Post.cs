using Application.Extentions;

namespace Application.Entities
{
    public class Post : Entity
    {
        public int Id { get; private set; }

		public string Title { get; private set; }
		public string NormalizedTitle { get; private set; }
		public string Content { get; private set; }
		public int CountOfImages { get; private set; }
		public int UserId { get; private set; }
		public int CategoryId { get; private set; }

		public User User { get; }
		public Category Category { get; }
        public IReadOnlyCollection<Swapping> RequesterSwappings { get; }
        public IReadOnlyCollection<Swapping> RequestedSwappings { get; }
		public IReadOnlyCollection<Comment> Comments { get; }
        public IReadOnlyCollection<UserPostLiking> UsersWhoLiked => _usersWhoLiked;
		public IReadOnlyCollection<PostImage> PostImages => _images;
		public IReadOnlyCollection<Requesting> RequestedPosts => _requestedPosts;
		public IReadOnlyCollection<Requesting> RequesterPosts => _requesterPosts;
		public IReadOnlyCollection<PostTag> Tags { get; }
        public IReadOnlyCollection<UserPostExploring> UserPostExplorings => _userPostExplorings;

		private readonly List<PostImage> _images = new();
        private readonly List<UserPostLiking> _usersWhoLiked = new();
        private readonly List<UserPostExploring> _userPostExplorings = new();
        private readonly List<Requesting> _requestedPosts = new();
        private readonly List<Requesting> _requesterPosts = new();
        private readonly List<Swapping> _requesterSwappings = new();


		public override int[] GetKey()
		{
            return new[] { Id };
		}

		public Post(int userId, string title, string content, int categoryId,int countOfImages)
        {
            UserId = userId;
			CategoryId = categoryId;
			Title = title;
            NormalizedTitle = title.CustomNormalize()!;
            Content = content;
            CountOfImages = countOfImages;
        }


        public void Update(string title) { 
            Title = title;
        }

        //post images
        public void AddImage(string blobName, string extention, int index)
        {
            _images.Add(new PostImage(blobName,extention,index));
            CountOfImages++;
		}
        public void RemoveImage(int postImageId)
        {
            var image = _images.First(x => x.Id == postImageId);
            image.Remove();
		}
        public void DeleteImage(int postImageId)
        {
            var index = _images.FindIndex(x => x.Id == postImageId);
            _images.RemoveAt(index);
        }

        //like
        public void Like(int userId)
        {
            _usersWhoLiked.Add(new UserPostLiking(userId, Id));
        }
        public void Dislike(int userId)
        {
            var index = _usersWhoLiked.FindIndex(x => x.UserId == userId);
            _usersWhoLiked.RemoveAt(index);
        }

        //expoloring Posts
        public void Explore(int userId)
        {
            _userPostExplorings.Add(new UserPostExploring(userId, Id));
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
