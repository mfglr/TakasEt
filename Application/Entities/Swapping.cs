namespace Application.Entities
{
	public class Swapping : Entity
	{
        public int DestinationPostId { get; private set; }
        public Post DestinationPost { get; }
		public int Rate {  get; private set; }
		public IReadOnlyCollection<SwappingComment> SwappingComments => _swappingComments;

		private List<SwappingComment> _swappingComments = new();

        public Swapping(int destinationPostId, int rate)
		{
			DestinationPostId = destinationPostId;
			Rate = rate;
		}

		public void addSWappingComment(int userId,int swappingCommentContentId)
		{
			_swappingComments.Add(new SwappingComment(userId, swappingCommentContentId));
		}

		public void addSwappingComments(int userId,List<int> swappingCommentContentIds)
		{
			foreach(var swappingCommentContentId in swappingCommentContentIds)
				_swappingComments.Add(new SwappingComment(userId, swappingCommentContentId));
		}

	}
}
