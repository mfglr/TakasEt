﻿using ChatMicroservice.Application.Dtos;
using ChatMicroservice.Core.Interfaces;
using ChatMicroservice.Domain.GroupAggregate;
using ChatMicroservice.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.IntegrationEvents;
using SharedLibrary.Services;

namespace ChatMicroservice.Application.Commands
{
    public class MakeRequestToJoinGroupCommandHandler : IRequestHandler<MakeRequestToJoinGroupDto, AppResponseDto>
	{
		private readonly ChatDbContext _context;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IIntegrationEventsPublisher _notificationPublisher;

        public MakeRequestToJoinGroupCommandHandler(ChatDbContext context, IUnitOfWork unitOfWork, IIntegrationEventsPublisher notificationPublisher)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _notificationPublisher = notificationPublisher;
        }

		public async Task<AppResponseDto> Handle(MakeRequestToJoinGroupDto request, CancellationToken cancellationToken)
		{
			var group = await _context
				.Groups
				.Include(x => x.Users)
				.Include(x => x.UsersWhoWantsToJoinTheGroup)
				.FirstOrDefaultAsync(x => x.Id == request.GroupId, cancellationToken);

			if (group == null) throw new Exception("Group is not found!");

			group.MakeRequestToJoin(request.UserId);

			var numberOfChanges = await _unitOfWork.CommitAsync(cancellationToken);
			if (numberOfChanges <= 0) throw new Exception("error");

			group.AddIntegrationEvent(
				new RequestToJoinToGroup_Created_Event()
				{
                    AdminIds = group.Users.Where(x => x.Role == UserRole.Admin).Select(x => x.UserId).ToList(),
                    GroupId = request.GroupId,
                    IdOfUserWhoWantsToJoinGroup = request.UserId
                }
            );
			return AppResponseDto.Success();
		}
	}
}
