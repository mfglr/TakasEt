﻿using ConversationService.Application.Dtos;
using ConversationService.Infrastructure;
using MediatR;
using SharedLibrary.Dtos;
using SharedLibrary.Exceptions;
using SharedLibrary.UnitOfWork;
using System.Net;

namespace ConversationService.Application.Commands
{
    public class MarkMessageAsViewedCommandHandler : IRequestHandler<MarkMessageAsViewedDto, IAppResponseDto>
    {

        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public MarkMessageAsViewedCommandHandler(AppDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<IAppResponseDto> Handle(MarkMessageAsViewedDto request, CancellationToken cancellationToken)
        {
            var message = await _context.Messages.FindAsync(request.MessageId,cancellationToken);
            if (message == null)
                throw new AppException("The message was not found!", HttpStatusCode.NotFound);
            message.MarkAsViewed(new Guid(),request.ViewedDate);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new AppSuccessResponseDto();
        }
    } 
}
