using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetCommentsByPostId : Pagination,IRequest<AppResponseDto>
	{
        public Guid PostId { get; private set; }

		public GetCommentsByPostId(Guid postId,IQueryCollection collection) : base(collection)
		{
			PostId = postId;
		}
	}
}
