using AutoMapper;
using ConversationService.Application.Dtos;
using ConversationService.Application.Hubs;
using ConversationService.Domain.DomainEvents;
using ConversationService.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;

namespace ConversationService.Application.DomainEventHandlers
{
    public class OnMarkedMessageAsReceived_SendNotificationToSender : INotificationHandler<MessageMarkedAsReceivedDomainEvent>
    {
        private readonly IHubContext<MessageHub> _conversationHub;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public OnMarkedMessageAsReceived_SendNotificationToSender(IHubContext<MessageHub> conversationHub, AppDbContext context, IMapper mapper)
        {
            _conversationHub = conversationHub;
            _context = context;
            _mapper = mapper;
        }

        public async Task Handle(MessageMarkedAsReceivedDomainEvent notification, CancellationToken cancellationToken)
        {
            var sender = await _context
                .UserConnections
                .FirstOrDefaultAsync(x => x.Id == notification.Message.SenderId,cancellationToken);

            if (sender != null && sender.IsConnected)
            {
                await _conversationHub
                    .Clients
                    .Client(sender.ConnectionId)
                    .SendAsync(
                        "messageReceivedNotification",
                        new AppGenericSuccessResponseDto<MessageResponseDto>(_mapper.Map<MessageResponseDto>(notification.Message)),
                        cancellationToken
                    );
            }

        }
    }
}
