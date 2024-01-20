namespace Application.Entities
{
	public class SwappingCommentContent : Entity
	{
        public string Content { get; private set; }
		public IReadOnlyCollection<SwappingComment> SwappingComments { get; }

		public SwappingCommentContent(string content)
		{
			Content = content;
		}

	}
}
