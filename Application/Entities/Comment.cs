namespace Application.Entities
{
    public class Comment : RecursiveEntity<Comment>
    {
        public Guid ArticleId { get; private set; }
		public Article Article { get; }
		public Guid UserId { get; private set; }
		public User User { get; private set; }
        public string Content { get; private set; }
        public int NumberOfLikes { get; private set; } = 0;

		public Comment(Guid? parentId, Guid articleId, Guid userId, string content)
		{
			ParentId = parentId;
			ArticleId = articleId;
			UserId = userId;
			Content = content;
			NumberOfLikes = 0;
		}

	}
}
