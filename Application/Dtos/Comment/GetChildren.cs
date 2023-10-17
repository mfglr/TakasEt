using MediatR;

namespace Application.Dtos
{
	public class GetChildren : IRequest<AppResponseDto>
	{
        public Guid ParentId { get; private set; }

		public GetChildren(Guid parentId)
		{
			ParentId = parentId;
		}
	}
}
