using MediatR;

namespace Application.Dtos
{
	public class GetFirstImagesOfPostsExceptRequesters : IRequest<byte[]>
	{
        public Guid PostId { get; private set; }

		public GetFirstImagesOfPostsExceptRequesters(Guid postId){ PostId = postId; }
	}
}
