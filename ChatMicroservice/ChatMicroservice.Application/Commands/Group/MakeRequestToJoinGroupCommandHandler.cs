﻿using AutoMapper;
using ChatMicroservice.Application.Dtos;
using ChatMicroservice.Core.Interfaces;
using ChatMicroservice.Domain.GroupAggregate;
using ChatMicroservice.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.Messages;
using SharedLibrary.Services;
using SharedLibrary.ValueObjects;

namespace ChatMicroservice.Application.Commands
{
	public class MakeRequestToJoinGroupCommandHandler : IRequestHandler<MakeRequestToJoinGroupDto, AppResponseDto>
	{
		private readonly ChatDbContext _context;
		private readonly IUnitOfWork _unitOfWork;
		private readonly NotificationPublisher _notificationPublisher;

        public MakeRequestToJoinGroupCommandHandler(ChatDbContext context, IUnitOfWork unitOfWork, NotificationPublisher notificationPublisher)
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
				.FirstOrDefaultAsync(x => x.Id == request.GroupId, cancellationToken);

			if (group == null) throw new Exception("Group is not found!");
			
			group.MakeRequestToJoin(request.UserId);

			var numberOfChanges = await _unitOfWork.CommitAsync(cancellationToken);
			if (numberOfChanges <= 0) throw new Exception("error");

			_notificationPublisher.Publish(
				new RequestedJoinToGroup()
				{
					AdminIds = group.Users.Where(x => x.Role == UserRole.Admin).Select(x=> x.Id).ToList(),
					GroupId = request.GroupId,
					UserId = request.UserId
				},
				Queue.ReqeustToJoinGroup
			);

			return AppResponseDto.Success();

		}
	}
}
