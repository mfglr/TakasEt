namespace Application.Entities
{
	public class SwappingCommentContent : Entity
	{
		public int Id { get; private set; }
        public string Content { get; private set; }
		public IReadOnlyCollection<SwappingComment> SwappingComments { get; }

		public override int[] GetKey()
		{
			return new[] { Id };
		}

		public SwappingCommentContent(string content)
		{
			Content = content;
		}

		
	}
}
