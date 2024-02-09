using ChatMicroservice.Application.Dtos;
using ChatMicroservice.Domain.GroupAggregate;
using ChatMicroservice.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace ChatMicroservice.Application.Hubs
{
    public class ChatHub : Hub
    {

        private readonly ISender _sender;
        private readonly ChatDbContext _context;

        public ChatHub(ISender sender, ChatDbContext context)
        {
            _sender = sender;
            _context = context;
        }

        public async Task Connect(ConnectDto request, CancellationToken cancellationToken)
        {
            var response = await _sender.Send(request, cancellationToken);
            await Clients.Caller.SendAsync("connectionSuccessNotification", response, cancellationToken);
        }

        public async Task Disconnect(DisconnectDto request, CancellationToken cancellationToken)
        {
            var response = await _sender.Send(request, cancellationToken);
            await Clients.Caller.SendAsync("disconnectionSuccessNotification", response, cancellationToken);
        }

        public async Task SendMessageToGroup(SaveGroupMessageDto request, CancellationToken cancellationToken)
        {
            var response = await _sender.Send(request, cancellationToken);
            await Clients.Caller.SendAsync("messageSavedSuccessNotification", cancellationToken);
           
            var connections = await (
                from connection in _context.Set<Domain.ConnectionAggregate.Connection>()
                join groupUser in _context.Set<GroupUser>()
                on connection.UserId equals groupUser.UserId
                where groupUser.GroupId == request.GroupId
                select connection
            )
            .ToListAsync(cancellationToken);

            foreach (var connection in connections)
                if(connection.Connected)
                    await Clients
                        .Client(connection.ConnectionId)
                        .SendAsync("newMessageCommingNotification", response, cancellationToken);
        }

    }
}
