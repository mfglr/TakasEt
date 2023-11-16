using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetCommentsByPostId : Pagination, IRequest<byte[]>
	{
        public int PostId { get; private set; }

		public GetCommentsByPostId(int postId,IQueryCollection collection) : base(collection)
		{
			PostId = postId;
		}
	}
}
