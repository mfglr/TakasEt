using AutoMapper;
using ConversationService.Application.Dtos;
using ConversationService.Application.Hubs;
using ConversationService.Domain.DomainEvents;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using SharedLibrary.Services;

namespace ConversationService.Application.DomainEventsHandlers
{
    public class OnMessageMarkedAsReceived_SendNotificationToSender : INotificationHandler<MessageMarkedAsReceivedDomainEvent>
    {
        private readonly IMapper _mapper;
        private readonly DateTimeService _dateTimeService;
        private readonly IHubContext<MessageHub> _messageHub;

        public OnMessageMarkedAsReceived_SendNotificationToSender(IMapper mapper, DateTimeService dateTimeService, IHubContext<MessageHub> messageHub)
        {
            _mapper = mapper;
            _dateTimeService = dateTimeService;
            _messageHub = messageHub;
        }

        public async Task Handle(MessageMarkedAsReceivedDomainEvent notification, CancellationToken cancellationToken)
        {
            if(notification.Message.Sender != null && notification.Message.Sender.IsConnected)
            {
                var response = _mapper.Map<MessageResponseDto>(notification.Message);
                _dateTimeService.ConvertDateTimesRecursive(response);

                await _messageHub
                    .Clients
                    .Client(notification.Message.Sender.ConnectionId)
                    .SendAsync("messageReceivedNotification", response,cancellationToken);
            }
                
        }
    }
}
