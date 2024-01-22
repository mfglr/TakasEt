using Application.ValueObjects;

namespace Application.Entities
{
	public class Swapping : CrossEntity
	{
		public int RequesterId { get; private set; }
		public int RequestedId { get; private set; }
		public SwappingStatus Status { get; private set; }

		public Post Requester { get; }
		public Post Requested { get; }
		public IReadOnlyCollection<SwappingComment> SwappingComments => _swappingComments;

		private List<SwappingComment> _swappingComments = new();

		public override int[] GetKey()
		{
			return new[] { RequesterId, RequestedId };
		}

		public Swapping(int requesterId,int requestedId)
		{
			RequesterId = requesterId;
			RequestedId = requestedId;
			Status = SwappingStatus.Approved;
		}

		public void Cancel()
		{
			Status = SwappingStatus.Canceled;
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
