using AutoMapper;
using Azure;
using ConversationService.Application.Dtos;
using ConversationService.Application.Hubs;
using ConversationService.Domain.DomainEvents;
using ConversationService.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using SharedLibrary.Services;

namespace ConversationService.Application.DomainEventsHandlers
{
    public class OnMessageCreated_SendNotificationToSender : INotificationHandler<MessageCreatedDomainEvent>
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private readonly DateTimeService _dateTimeService;
        private readonly IHubContext<MessageHub> _messageHub;

        public OnMessageCreated_SendNotificationToSender(IMapper mapper, AppDbContext context, DateTimeService dateTimeService, IHubContext<MessageHub> messageHub)
        {
            _mapper = mapper;
            _context = context;
            _dateTimeService = dateTimeService;
            _messageHub = messageHub;
        }

        public async Task Handle(MessageCreatedDomainEvent notification, CancellationToken cancellationToken)
        {

            var senderId = notification.Message.SenderId;
            var sender = await _context.UserConnections.FindAsync(senderId, cancellationToken);

            if (sender != null && sender.IsConnected)
            {
                var response = _mapper.Map<MessageResponseDto>(notification.Message);
                _dateTimeService.ConvertDateTimesRecursive(response);

                await _messageHub
                    .Clients
                    .Client(sender.ConnectionId)
                    .SendAsync("messageCreationCompletedNotification", response);
            }


        }
    }
}
