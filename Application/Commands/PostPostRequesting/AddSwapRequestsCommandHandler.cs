using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using MediatR;

namespace Application.Commands
{
	public class AddSwapRequestsCommandHandler : IRequestHandler<AddSwapRequestsRequestDto, AppResponseDto>
	{

		private readonly IRepository<PostPostRequesting> _swapRequests;

		public AddSwapRequestsCommandHandler(IRepository<PostPostRequesting> swapRequests)
		{
			_swapRequests = swapRequests;
		}

		public async Task<AppResponseDto> Handle(AddSwapRequestsRequestDto request, CancellationToken cancellationToken)
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
