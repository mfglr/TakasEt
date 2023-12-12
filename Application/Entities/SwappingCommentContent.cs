namespace Application.Entities
{
	public class SwappingCommentContent : Entity
	{
        public int Content { get; private set; }
		public IReadOnlyCollection<SwappingComment> SwappingComments { get; }
    }
}
