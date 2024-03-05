using ConversationService.Application.Dtos;
using ConversationService.Infrastructure;
using ConversationService.SignalR.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.Extentions;
using SharedLibrary.Services;

namespace ConversationService.Api.Hubs
{
    [Authorize(Roles = "user")]
    public class ConversationHub : Hub
    {
        private readonly ISender _sender;
        private readonly AppDbContext _context;
        private readonly BlockingService _blockingChecker;

        public ConversationHub(ISender sender, AppDbContext context, BlockingService blockingChecker)
        {
            _sender = sender;
            _context = context;
            _blockingChecker = blockingChecker;
        }

        public override async Task OnConnectedAsync()
        {
            try
            {
                var loginUserId = Guid.Parse(Context.GetHttpContext()!.GetLoginUserId()!);
                await _sender.Send(
                    new ConnectDto() {
                        ConnectionId = Context.ConnectionId,
                        LoginUserId = loginUserId
                    }
                );
            }
            catch (Exception)
            {
                return;
            }
            await Clients.Caller.SendAsync("connectionCompleted");
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await _sender.Send(new DisconnectDto());
        }

        public async Task SendMessage(SaveMessageDto request)
        {
            IAppResponseDto response;
            try
            {
                request.SenderId = Guid.Parse(Context.GetHttpContext()!.GetLoginUserId()!);
                await _blockingChecker.ThrowExceptionIfBlockerOfBlockedAsync(Context.GetHttpContext()!, request.ReceiverId.ToString());
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
                request.ReceiverId = Guid.Parse(Context.GetHttpContext()!.GetLoginUserId()!);
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
