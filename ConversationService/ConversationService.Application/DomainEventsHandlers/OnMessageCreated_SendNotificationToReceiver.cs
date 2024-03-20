using AutoMapper;
using ConversationService.Application.Dtos;
using ConversationService.Application.Hubs;
using ConversationService.Domain.DomainEvents;
using ConversationService.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using SharedLibrary.Services;
using System.Reflection;

namespace ConversationService.Application.DomainEventsHandlers
{
    public class OnMessageCreated_SendNotificationToReceiver : INotificationHandler<MessageCreatedDomainEvent>
    {

        private readonly IMapper _mapper;
        private readonly IHubContext<MessageHub> _messageHub;
        private readonly AppDbContext _context;
        private readonly DateTimeService _dateTimeService;

        public OnMessageCreated_SendNotificationToReceiver(IMapper mapper, IHubContext<MessageHub> messageHub, AppDbContext context, DateTimeService dateTimeService)
        {
            _mapper = mapper;
            _messageHub = messageHub;
            _context = context;
            _dateTimeService = dateTimeService;
        }

        public async Task Handle(MessageCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            var receiverId = notification.Message.ReceiverId;
            var receiver = await _context.UserConnections.FindAsync(receiverId, cancellationToken);
            if (receiver != null && receiver.IsConnected)
            {
                var response = _mapper.Map<MessageResponseDto>(notification.Message);
                _dateTimeService.ConvertDateTimesRecursive(response);

                await _messageHub
                    .Clients
                    .Client(receiver.ConnectionId)
                    .SendAsync("receiveMessage", response);
            }
        }
    }
}
