﻿using ConversationService.Application.Dtos;
using ConversationService.Domain.ConversationAggregate;
using ConversationService.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.Extentions;
using SharedLibrary.UnitOfWork;

namespace ConversationService.Application.Commands
{
    public class MarkMessagesAsReceivedCommandHandler : IRequestHandler<MarkMessagesAsReceivedDto, IAppResponseDto>
    {

        private readonly IHttpContextAccessor _contextAccessor;
        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public MarkMessagesAsReceivedCommandHandler(IHttpContextAccessor contextAccessor, AppDbContext context, IUnitOfWork unitOfWork)
        {
            _contextAccessor = contextAccessor;
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<IAppResponseDto> Handle(MarkMessagesAsReceivedDto request, CancellationToken cancellationToken)
        {
            var loginUserId = Guid.Parse(_contextAccessor.HttpContext.GetLoginUserId()!);

            var conversations = await _context
                .Conversations
                .Include(x => x.Messages.Where(
                    x =>
                        x.MessageState.Status == MessageState.Created.Status &&
                        x.SenderId != loginUserId
                ))
                .Where(x => x.UserId1 == loginUserId || x.UserId2 == loginUserId)
                .ToListAsync(cancellationToken);

            foreach ( var conversation in conversations )
                conversation.MarkMessagesAsReceived(loginUserId, request.ReceivedDate);

            await _unitOfWork.CommitAsync(cancellationToken);
            return new AppSuccessResponseDto();
        }
    }
}
