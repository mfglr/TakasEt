using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetFirstImagesOfPostsByUserName : Pagination, IRequest<byte[]>
	{
        public string UserName { get; private set; }

		public GetFirstImagesOfPostsByUserName(string userName,IQueryCollection collection) : base(collection)
		{
			UserName = userName;

		}
	}
}
