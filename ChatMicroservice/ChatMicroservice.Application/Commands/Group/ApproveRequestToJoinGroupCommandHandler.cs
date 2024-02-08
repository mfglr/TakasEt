using ChatMicroservice.Application.Dtos.Group;
using ChatMicroservice.Core.Interfaces;
using ChatMicroservice.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.Messages;
using SharedLibrary.Services;
using SharedLibrary.ValueObjects;

namespace ChatMicroservice.Application.Commands
{
	public class ApproveRequestToJoinGroupCommandHandler : IRequestHandler<ApproveRequestToJoinGroupDto, AppResponseDto>
	{

		private readonly ChatDbContext _chatDbContext;
		private readonly IUnitOfWork _unitOfWork;
		private readonly NotificationPublisher _publisher;

        public ApproveRequestToJoinGroupCommandHandler(ChatDbContext chatDbContext, IUnitOfWork unitOfWork, NotificationPublisher publisher)
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

			_publisher.Publish(
				new ApprovedRequestToJoinGroupEvent() {
					ApproverId = request.IdOfUserApprovingRequest,
					GroupId = request.GroupId,
					IdOfUserWhoJoinedTheGroup = request.IdOfUserWhoWantsToJoin
				} ,
				Queue.ApproveRequestToJoinGroup
			);

			return AppResponseDto.Success();
		}
	}
}
