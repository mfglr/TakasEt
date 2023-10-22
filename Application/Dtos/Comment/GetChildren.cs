using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetChildren : Pagination, IRequest<AppResponseDto>
	{
        public Guid ParentId { get; private set; }

		public GetChildren(Guid parentId,IQueryCollection collection) : base(collection)
		{
			ParentId = parentId;
		}
	}
}
