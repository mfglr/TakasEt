using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetFirstImagesOfPosts : Pagination, IRequest<byte[]>
	{
		public GetFirstImagesOfPosts(IQueryCollection collection) : base(collection)
		{
		}
	}
}
