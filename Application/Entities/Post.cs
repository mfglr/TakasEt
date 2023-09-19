namespace Application.Entities
{
    public class Post : Entity
    {
        public Guid UserId { get; private set; }
        public User User { get; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public DateTime PublishedDate { get; private set; }
        public IReadOnlyCollection<Comment> Comments { get; }
        public IReadOnlyCollection<UserPostLikes> UsersWhoLiked { get; }
        public IReadOnlyCollection<UserPostViews> UsersWhoViewed { get; }
        public IReadOnlyCollection<AppFile> AppFiles { get; }
		public Guid CategoryId { get; private set; }
        public Category Category { get; }

        public Post(Guid userId,string title,string content,Guid categoryId)
        {
            UserId = userId;
            Title = title;
            Content = content;
            CategoryId = categoryId;
        }
        public void Publish()
        {
            PublishedDate = DateTime.UtcNow;
        }
    }
}
