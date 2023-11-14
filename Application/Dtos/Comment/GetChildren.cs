using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetChildren : Pagination, IRequest<AppResponseDto>
	{
        public int ParentId { get; private set; }

		public GetChildren(int parentId,IQueryCollection collection) : base(collection)
		{
			ParentId = parentId;
		}
	}
}
