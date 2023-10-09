namespace Application.Entities
{
	public class PostPostRequesting : Entity
	{
		public Guid RequesterId { get; private set; }
		public Post Requester { get; } // isteyen
		public Guid RequestedId { get; private set; }
        public Post Requested { get; } // istenilen
        

		public PostPostRequesting(Guid requesterId, Guid requestedId)
		{
			RequesterId = requesterId;
			RequestedId = requestedId;
		}
	}
}
