using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using MediatR;

namespace Handler.Commands
{
	public class AddRequestingCommandHandler : IRequestHandler<AddRequestings, AppResponseDto>
	{

		private readonly IRepository<PostPostRequesting> _swapRequests;

		public AddRequestingCommandHandler(IRepository<PostPostRequesting> swapRequests)
		{
			_swapRequests = swapRequests;
		}

		public async Task<AppResponseDto> Handle(AddRequestings request, CancellationToken cancellationToken)
		{
			var swapRequests = new List<PostPostRequesting>();
			foreach (var requesterId in request.RequesterIds)
				swapRequests.Add(new PostPostRequesting(requesterId, request.RequestedId));
			await _swapRequests
				.DbSet
				.AddRangeAsync(swapRequests);
			return AppResponseDto.Success();
		}
	}
}
