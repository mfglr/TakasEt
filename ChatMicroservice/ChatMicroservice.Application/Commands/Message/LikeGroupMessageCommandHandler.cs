using ChatMicroservice.Application.Dtos;
using ChatMicroservice.Application.Hubs;
using ChatMicroservice.Core.Interfaces;
using ChatMicroservice.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.Exceptions;
using System.Net;

namespace ChatMicroservice.Application.Commands.Message
{
    public class LikeGroupMessageCommandHandler : IRequestHandler<LikeGroupMessageDto, AppResponseDto>
    {

        private readonly ChatDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public LikeGroupMessageCommandHandler(ChatDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
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
            
            group.LikeMessage(request.MessageId,request.UserId);
            
            await _unitOfWork.CommitAsync(cancellationToken);
            return AppResponseDto.Success();

        }
    }
}
