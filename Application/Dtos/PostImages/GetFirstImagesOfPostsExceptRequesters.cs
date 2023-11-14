using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetFirstImagesOfPostsExceptRequesters : Pagination, IRequest<byte[]>
	{
        public int PostId { get; private set; }

		public GetFirstImagesOfPostsExceptRequesters(int postId,IQueryCollection collection) : base(collection)
		{ PostId = postId; }
	}
}
