using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetCommentsByPostId : Page, IRequest<AppResponseDto>
	{
        public int PostId { get; private set; }

		public GetCommentsByPostId(int postId,IQueryCollection collection) : base(collection)
		{
			PostId = postId;
		}
	}
}
