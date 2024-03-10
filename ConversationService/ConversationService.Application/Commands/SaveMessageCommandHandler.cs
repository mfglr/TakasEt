using AutoMapper;
using ConversationService.Application.Dtos;
using ConversationService.Domain.ConversationAggregate;
using ConversationService.Domain.MessageAggregate;
using ConversationService.Infrastructure;
using ConversationService.SignalR.Dtos;
using MediatR;
using SharedLibrary.Extentions;
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
            Message message = new Message(
                request.Id,
                request.SenderId,
                request.ReceiverId,
                request.Content,
                request.SendDate.ToDateTime()
            );

            var conversationKey = new List<Guid>() { request.SenderId, request.ReceiverId }.OrderBy(x => x);
            var conversation = await _context
                .Conversations
                .FindAsync(conversationKey, cancellationToken);
            
            if(conversation == null)
            {
                conversation = new Conversation(request.SenderId, request.ReceiverId);
                conversation.AddMessage(message);
                await _context.Conversations.AddAsync(conversation,cancellationToken);
            }
            else
                conversation.AddMessage(message);

            await _unitOfWork.CommitAsync(cancellationToken);
            return _mapper.Map<MessageResponseDto>(message);
        }
    }
}
