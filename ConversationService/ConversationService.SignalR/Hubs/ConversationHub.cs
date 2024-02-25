using ConversationService.Application.Dtos;
using ConversationService.Infrastructure;
using ConversationService.SignalR.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;

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
            catch (Exception)
            {
                return;
            }
            await Clients.Caller.SendAsync("ConnectionCompleted", response);
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
                    .SendAsync("DisconnectionFailed", new AppFailResponseDto(ex.Message));
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
                    .SendAsync("messageSaveFailed",new AppFailResponseDto(ex.Message));
                return;
            }

            await Clients.Caller.SendAsync("messageSaveCompleted",response);

            var receiver = await _context.UserConnections.FirstOrDefaultAsync(x => x.Id == request.ReceiverId);

            if (receiver == null) {
                await Clients
                    .Caller
                    .SendAsync("messageSendFailed", new AppFailResponseDto("User was not found!"));
                return;
            }

            if (receiver.IsConnected)
                await Clients
                    .Clients(receiver.ConnectionId!)
                    .SendAsync("receiveMessage",response);
        }
        public async Task SendMessageReceivedNotification(SendMessageReceivedNotificationDto request)
        {
            IAppResponseDto response;
            try
            {
                response = await _sender.Send(request);
            }
            catch (Exception)
            {
                return;
            }
            var message = await _context
                .Messages
                .Include(x => x.Sender)
                .FirstOrDefaultAsync(x => x.Id == request.MessageId);
            
            if(message != null && message.Sender.IsConnected && message.Sender.ConnectionId != null)
                await Clients.Clients(message.Sender.ConnectionId).SendAsync("messageReceived", response);
        }
        public async Task SendMessageViewedNotification(SendMessageViewedNotificationDto request)
        {
            IAppResponseDto response;
            try
            {
                response = await _sender.Send(request);
            }
            catch (Exception)
            {
                return;
            }
            var message = await _context
                .Messages
                .Include(x => x.Sender)
                .FirstOrDefaultAsync(x => x.Id == request.MessageId);

            if (message != null && message.Sender.IsConnected && message.Sender.ConnectionId != null)
                await Clients.Clients(message.Sender.ConnectionId).SendAsync("messageViewed", response);
        }
        public async Task LikeMessage(LikeMessageDto request)
        {
            IAppResponseDto response;
            try
            {
                response = await _sender.Send(request);
            }
            catch (Exception ex)
            {
                await Clients
                    .Caller
                    .SendAsync("LikeMessageFailed", new AppFailResponseDto(ex.Message));
                return;
            }
            var message = await _context
                .Messages
                .Include(x => x.Sender)
                .FirstOrDefaultAsync(x => x.Id == request.MessageId);
            
            if (message != null && message.Sender.IsConnected && message.Sender.ConnectionId != null)
                await Clients.Clients(message.Sender.ConnectionId).SendAsync("messageLiked", response);
        }
    }
}
