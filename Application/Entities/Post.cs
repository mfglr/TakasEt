using Application.Extentions;
using Newtonsoft.Json;

namespace Application.Entities
{
    public class Post : Entity
    {
        public Guid UserId { get; private set; }
		public Guid CategoryId { get; private set; }
        public string Title { get; private set; }
        public string NormalizedTitle { get; private set; }
        public string Content { get; private set; }
        public int CountOfImages { get; private set; }
        public User User { get; }
        public Category Category { get; }
		public IReadOnlyCollection<Comment> Comments { get; }
        public IReadOnlyCollection<UserPostLiking> UsersWhoLiked { get; }
        public IReadOnlyCollection<UserPostViewing> UsersWhoViewed { get; }
        public IReadOnlyCollection<PostImage> PostImages { get; }
        public IReadOnlyCollection<PostPostRequesting> Requesteds { get; }//talep ettikleri
		public IReadOnlyCollection<PostPostRequesting> Requesters { get; }//telap edenler
        public IReadOnlyCollection<UserPostFollowing> UsersFollowingThePost { get; }
        
        
        public Post(Guid userId, string title, string content, Guid categoryId,int countOfImages)
        {
            UserId = userId;
			CategoryId = categoryId;
			Title = title;
            NormalizedTitle = title.CustomNormalize();
            Content = content;
            CountOfImages = countOfImages;
        }

        [JsonConstructor]
		public Post(Guid id,Guid userId, string title, string content, Guid categoryId, int countOfImages,DateTime createddate)
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
