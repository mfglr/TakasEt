using AutoMapper;
using ConversationService.Application.Dtos;
using ConversationService.Domain.ConversationAggregate;
using ConversationService.Infrastructure;
using ConversationService.SignalR.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.UnitOfWork;

namespace ConversationService.Application.Commands
{
    public class SaveMessageCommandHandler : IRequestHandler<SaveMessageDto, MessageResponseDto>
    {

        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SaveMessageCommandHandler(AppDbContext context, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<MessageResponseDto> Handle(SaveMessageDto request, CancellationToken cancellationToken)
        {
            var conversation = await _context
                .Conversations
                .FirstOrDefaultAsync(
                    x =>
                        x.UserId1 == request.ReceiverId && x.UserId2 == request.SenderId ||
                        x.UserId1 == request.SenderId && x.UserId2 == request.ReceiverId,
                    cancellationToken
                );

            Message message;
            if(conversation == null)
            {
                conversation = new Conversation(request.SenderId, request.ReceiverId);
                message = conversation.AddMessage(request.Id, request.SenderId, request.ReceiverId, request.Content,request.SendDate);
                await _context.Conversations.AddAsync(conversation, cancellationToken);
            }
            else
                message = conversation.AddMessage(request.Id,request.SenderId, request.ReceiverId, request.Content,request.SendDate);
            await _unitOfWork.CommitAsync(cancellationToken);
            return _mapper.Map<MessageResponseDto>(message);
        }
    }
}
