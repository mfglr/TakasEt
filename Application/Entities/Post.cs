namespace Application.Entities
{
    public class Post : Entity
    {
        public Guid UserId { get; private set; }
		public Guid CategoryId { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public DateTime PublishedDate { get; private set; }
		public User User { get; }
        public Category Category { get; }
		public IReadOnlyCollection<Comment> Comments { get; }
        public IReadOnlyCollection<UserPostLikes> UsersWhoLiked { get; }
        public IReadOnlyCollection<UserPostViews> UsersWhoViewed { get; }
        public IReadOnlyCollection<PostImage> PostImages { get; }

        public Post(Guid userId, string title, string content, Guid categoryId)
        {
            UserId = userId;
			CategoryId = categoryId;
			Title = title;
            Content = content;
        }
        public void Publish()
        {
            PublishedDate = DateTime.UtcNow;
        }
    }
}
