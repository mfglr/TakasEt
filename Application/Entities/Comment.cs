namespace Application.Entities
{
    public class Comment : Entity
    {
        public Guid ArticleId { get; private set; }
		public Guid UserId { get; private set; }

        public string Content { get; private set; }
        public int NumberOfLikes { get; private set; } = 0;

		public Comment(Guid articleId, Guid userId,  string content)
		{
			ArticleId = articleId;
			Content = content;
			UserId = userId;
		}

	}
}
