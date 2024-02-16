using ChatMicroservice.Application.Dtos;
using ChatMicroservice.Core.Interfaces;
using ChatMicroservice.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.Exceptions;
using SharedLibrary.IntegrationEvents;
using SharedLibrary.Services;
using System.Net;

namespace ChatMicroservice.Application.Commands
{
    public class LikeGroupMessageCommandHandler : IRequestHandler<LikeGroupMessageDto, AppResponseDto>
    {

        private readonly ChatDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IIntegrationEventsPublisher _publisher;

        public LikeGroupMessageCommandHandler(ChatDbContext context, IUnitOfWork unitOfWork, IIntegrationEventsPublisher publisher)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _publisher = publisher;
        }

        public async Task<AppResponseDto> Handle(LikeGroupMessageDto request, CancellationToken cancellationToken)
        {
            var group = await _context
                .Groups
                .Include(x => x.Users)
                .Include(x => x.Messages.FirstOrDefault(x => x.Id == request.MessageId))
                .FirstOrDefaultAsync(x => x.Id == request.GroupId, cancellationToken);
            if (group == null)
                throw new AppException("The group was not found!", HttpStatusCode.NotFound);
            
            var message = group.LikeMessage(request.MessageId,request.LikerId);
            
            await _unitOfWork.CommitAsync(cancellationToken);

            message.AddIntegrationEvent(
                new Message_Liked_Event()
                {
                    IdOfMessageOwner = message.SenderId,
                    MessageId = message.Id,
                    IdOfUserWhoLikedTheMessage = request.LikerId
                } 
            );
            return AppResponseDto.Success();

        }
    }
}
