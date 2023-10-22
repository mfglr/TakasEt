using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetPostsByUserName : Pagination, IRequest<AppResponseDto>
	{
        public string UserName { get; private set; }

		public GetPostsByUserName(string userName,IQueryCollection collection) : base(collection)
		{
			UserName = userName;
		}
	}
}
