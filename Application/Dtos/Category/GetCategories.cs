using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetCategories : Pagination, IRequest<AppResponseDto>
	{
		public GetCategories(IQueryCollection collection) : base(collection)
		{
		}
	}
}
