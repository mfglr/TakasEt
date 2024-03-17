using ConversationService.Application.Dtos;
using ConversationService.Infrastructure;
using ConversationService.SignalR.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.Extentions;

namespace ConversationService.Application.Hubs
{
    [Authorize(Roles = "user")]
    public class MessageHub : Hub
    {
        private readonly ISender _sender;
        private readonly AppDbContext _context;

        public MessageHub(ISender sender, AppDbContext context)
        {
            _sender = sender;
            _context = context;
        }

        public override async Task OnConnectedAsync()
        {
            try
            {
                await _sender.Send(new ConnectDto() {ConnectionId = Context.ConnectionId});
            }
            catch (Exception)
            {
                return;
            }
            await Clients
                .Caller
                .SendAsync("connectionCompletedNotification");
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
                response = await _sender.Send(request);
            }
            catch(Exception ex)
            {
                await Clients
                    .Caller
                    .SendAsync("messageSaveFailedNotification",new AppFailResponseDto(ex.Message));
                return;
            }

            await Clients.Caller.SendAsync("messageSaveCompletedNotification",response);

            var receiver = await _context.UserConnections.FirstOrDefaultAsync(x => x.Id == request.ReceiverId);

            if (receiver == null) {
                await Clients
                    .Caller
                    .SendAsync("messageSendFailedNotification", new AppFailResponseDto("User was not found!"));
                return;
            }

            if (receiver.IsConnected)
                await Clients
                    .Clients(receiver.ConnectionId!)
                    .SendAsync("receiveMessage",response);
        }

        public async Task GetNewMessages()
        {
            IAppResponseDto response;
            try
            {
                response = await _sender.Send(new GetNewMessagesDto());
            }
            catch(Exception)
            {
                await Clients.Caller.SendAsync("synchronizedFailedNotification");
                return;
            }

            await Clients.Caller.SendAsync("receiveNewMessages", response);
        }

        public async Task MarkMessagesAsReceived(MarkMessagesAsReceivedDto request)
        {
            IAppResponseDto response;
            try
            {
                response = await _sender.Send(request);
            }catch(Exception)
            {
                await Clients.Caller.SendAsync("synchronizedFailedNotification");
                return;
            }

            await Clients.Caller.SendAsync("synchronizedSuccessNotification");

            var messages = (response as AppGenericSuccessResponseDto<List<MessageResponseDto>>)!.Data;
            foreach(var message in messages)
            {
                if (message.Sender != null && message.Sender.IsConnected)
                {
                    await Clients
                        .Client(message.Sender.ConnectionId)
                        .SendAsync(
                            "messageReceivedNotification",
                            new AppGenericSuccessResponseDto<MessageResponseDto>(message)
                        );
                }
            }
        }

        public async Task SendMessageReceivedNotification(MarkMessageAsReceivedDto request)
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

            var sender = (await _context
                .Messages
                .Include(x => x.Sender)
                .FirstOrDefaultAsync(x => x.Id == request.MessageId))?
                .Sender;

            if (sender != null && sender.IsConnected && sender.ConnectionId != null)
                await Clients
                    .Clients(sender.ConnectionId)
                    .SendAsync("messageReceivedNotification",response);
        }

        public async Task SendMessageViewedNotification(MarkMessageAsViewedDto request)
        {
            Guid loginUserId = Guid.Parse(Context.GetHttpContext()!.GetLoginUserId()!);
            IAppResponseDto response;
            try
            {
                response = await _sender.Send(request);
            }
            catch (Exception)
            {
                return;
            }

            var senderId = (response as AppGenericSuccessResponseDto<MessageResponseDto>)!.Data.SenderId;
            var sender = await _context
                .UserConnections
                .FirstOrDefaultAsync(x => x.Id == senderId);
            if (sender != null && sender.IsConnected && sender.ConnectionId != null)
                await Clients
                    .Clients(sender.ConnectionId)
                    .SendAsync("messageViewedNotification",response);
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
