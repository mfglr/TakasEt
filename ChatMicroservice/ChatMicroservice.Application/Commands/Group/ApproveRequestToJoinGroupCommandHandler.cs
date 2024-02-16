using ChatMicroservice.Application.Dtos.Group;
using ChatMicroservice.Core.Interfaces;
using ChatMicroservice.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.IntegrationEvents;
using SharedLibrary.Services;

namespace ChatMicroservice.Application.Commands
{
    public class ApproveRequestToJoinGroupCommandHandler : IRequestHandler<ApproveRequestToJoinGroupDto, AppResponseDto>
	{

		private readonly ChatDbContext _chatDbContext;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IIntegrationEventsPublisher _publisher;

        public ApproveRequestToJoinGroupCommandHandler(ChatDbContext chatDbContext, IUnitOfWork unitOfWork, IIntegrationEventsPublisher publisher)
        {
            _chatDbContext = chatDbContext;
            _unitOfWork = unitOfWork;
            _publisher = publisher;
        }

        public async Task<AppResponseDto> Handle(ApproveRequestToJoinGroupDto request, CancellationToken cancellationToken)
		{
			var group = await _chatDbContext
				.Groups
				.Include(x => x.Users)
				.Include(x => x.UsersWhoWantsToJoinTheGroup)
				.FirstOrDefaultAsync(x => x.Id == request.GroupId, cancellationToken);
			if (group == null) throw new Exception("Group is not found!");
			group.ApproveRequestToJoin(request.IdOfUserApprovingRequest, request.IdOfUserWhoWantsToJoin);
			await _unitOfWork.CommitAsync(cancellationToken);

			group.AddIntegrationEvent(
				new RequestToJoinGroup_Approved_Event()
				{
                    ApproverId = request.IdOfUserApprovingRequest,
                    GroupId = request.GroupId,
                    IdOfUserWhoJoinedTheGroup = request.IdOfUserWhoWantsToJoin
                }
			);
			return AppResponseDto.Success();
		}
	}
}
