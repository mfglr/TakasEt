using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetFirstImagesOfPostsExceptRequesters : Pagination, IRequest<byte[]>
	{
        public Guid PostId { get; private set; }

		public GetFirstImagesOfPostsExceptRequesters(Guid postId,IQueryCollection collection) : base(collection)
		{ PostId = postId; }
	}
}
