using Azure.Core;
using ConversationService.Application.Dtos;
using ConversationService.Infrastructure;
using ConversationService.SignalR.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Connections.Features;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.Extentions;

namespace ConversationService.SignalR.Hubs
{
    [Authorize(Roles = "user")]
    public class ConversationHub : Hub
    {
        private readonly ISender _sender;
        private readonly AppDbContext _context;

        public ConversationHub(ISender sender, AppDbContext context)
        {
            _sender = sender;
            _context = context;
        }

        public override async Task OnConnectedAsync()
        {
            IAppResponseDto response; 
            try
            {
                response = await _sender.Send( new ConnectDto() { ConnectionId = Context.ConnectionId } );
            }
            catch (Exception ex)
            {
                await Clients
                    .Caller
                    .SendAsync("ConnectionFailedNotification", new AppFailResponseDto(ex.Message));
                return;
            }
            await Clients.Caller.SendAsync("ConnectionSuccessNotification", response);
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            IAppResponseDto response;
            try
            {
                response = await _sender.Send(new DisconnectDto());
            }
            catch (Exception ex)
            {
                await Clients
                    .Caller
                    .SendAsync("DisconnectionFailedNotification", new AppFailResponseDto(ex.Message));
                return;
            }
        }

        public async Task SendMessage(SaveMessageDto request)
        {
            IAppResponseDto response;
            try
            {
                response = await _sender.Send(request);
            }
            catch(Exception ex)
            {
                await Clients
                    .Caller
                    .SendAsync("messageSavedFailedNotification",new AppFailResponseDto(ex.Message));
                return;
            }

            await Clients.Caller.SendAsync("messageSavedSuccessNotification",response);

            var receiver = await _context.UserConnections.FirstOrDefaultAsync(x => x.Id == request.ReceiverId);

            if (receiver == null) { 
                await Clients
                    .Caller
                    .SendAsync("messageDeleveryFailedNotification", new AppFailResponseDto("User was not found!"));
                return;
            }

            if (receiver.IsConnected)
                await Clients
                    .Clients(receiver.ConnectionId!)
                    .SendAsync("receiveMessage",response);
        }


    }
}
