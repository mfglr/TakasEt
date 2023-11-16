using Application.Extentions;
using Newtonsoft.Json;

namespace Application.Entities
{
    public class Post : Entity
    {
        public int UserId { get; private set; }
		public int CategoryId { get; private set; }
        public string Title { get; private set; }
        public string NormalizedTitle { get; private set; }
        public string Content { get; private set; }
        public int CountOfImages { get; private set; }
        
        public int CountOfComments { get; private set; }
        public int CountOfLikes { get; private set; }
        public int CountOfViewings { get; private set; }

        public User User { get; }
        public Category Category { get; }
		public IReadOnlyCollection<Comment> Comments { get; }
        public IReadOnlyCollection<UserPostLiking> UsersWhoLiked { get; }
        public IReadOnlyCollection<UserPostViewing> UsersWhoViewed { get; }
        public IReadOnlyCollection<PostImage> PostImages => _images;
		public IReadOnlyCollection<PostPostRequesting> Requesteds { get; }//talep ettikleri
		public IReadOnlyCollection<PostPostRequesting> Requesters { get; }//telap edenler


        private readonly List<PostImage> _images = new();

        public Post(int userId, string title, string content, int categoryId,int countOfImages)
        {
            UserId = userId;
			CategoryId = categoryId;
			Title = title;
            NormalizedTitle = title.CustomNormalize();
            Content = content;
            CountOfImages = countOfImages;
        }

        public void Update(string title) { 
            Title = title;
        }

        public void AddImage(PostImage image)
        {
            _images.Add(image);
        }

        [JsonConstructor]
		public Post(int id, int userId, string title, string content, int categoryId, int countOfImages,DateTime createddate)
		{
            Id = id;
			UserId = userId;
			CategoryId = categoryId;
			Title = title;
			NormalizedTitle = title.CustomNormalize();
			Content = content;
			CountOfImages = countOfImages;
            CreatedDate = createddate;
		}
	}
}
