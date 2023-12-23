using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetComments : Pagination, IRequest<AppResponseDto>
	{
		public GetComments(IQueryCollection collection) : base(collection)
		{
		}
	}
}
