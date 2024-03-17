using AutoMapper;
using ConversationService.Application.Dtos;
using ConversationService.Application.Hubs;
using ConversationService.Domain.DomainEvents;
using ConversationService.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace ConversationService.Application.DomainEventHandlers
{
    public class OnMarkedMessageAsViewed_SendNotificationToSender : INotificationHandler<MessageMarkedAsViewedDomainEvent>
    {

        private readonly IHubContext<MessageHub> _conversationHub;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public OnMarkedMessageAsViewed_SendNotificationToSender(IHubContext<MessageHub> conversationHub, AppDbContext context, IMapper mapper)
        {
            _conversationHub = conversationHub;
            _context = context;
            _mapper = mapper;
        }

        public async Task Handle(MessageMarkedAsViewedDomainEvent notification, CancellationToken cancellationToken)
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
                        "messageViewedNotification",
                        _mapper.Map<MessageResponseDto>(notification.Message),
                        cancellationToken
                    );
            }
                
                
        }
    }
}
