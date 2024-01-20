using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetPostImages : Page, IRequest<AppResponseDto>
	{
		public GetPostImages(IQueryCollection collection,int postId) : base(collection)
		{
			PostId = postId;
		}

		public int PostId { get; private set; }
	}
}
