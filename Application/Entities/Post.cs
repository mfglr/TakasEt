namespace Application.Entities
{
    public class Post : Entity
    {
        public Guid UserId { get; private set; }
		public Guid CategoryId { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public DateTime PublishedDate { get; private set; }
        public int CountOfImages { get; private set; }
        public User User { get; }
        public Category Category { get; }
		public IReadOnlyCollection<Comment> Comments { get; }
        public IReadOnlyCollection<UserPostLiking> UsersWhoLiked { get; }
        public IReadOnlyCollection<UserPostViewing> UsersWhoViewed { get; }
        public IReadOnlyCollection<PostImage> PostImages { get; }
        public IReadOnlyCollection<PostPostRequesting> Requesteds { get; }//talep ettikleri
		public IReadOnlyCollection<PostPostRequesting> Requesters { get; }//telap edenler


		public Post(Guid userId, string title, string content, Guid categoryId,int countOfImages)
        {
            UserId = userId;
			CategoryId = categoryId;
			Title = title;
            Content = content;
            CountOfImages = countOfImages;
        }
        public void Publish()
        {
            PublishedDate = DateTime.UtcNow;
        }
    }
}
