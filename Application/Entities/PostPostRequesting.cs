namespace Application.Entities
{
	public class PostPostRequesting : Entity
	{
		public int RequesterId { get; private set; }
		public Post Requester { get; } // isteyen
		public int RequestedId { get; private set; }
        public Post Requested { get; } // istenilen
        

		public PostPostRequesting(int requesterId, int requestedId)
		{
			RequesterId = requesterId;
			RequestedId = requestedId;
		}
	}
}
