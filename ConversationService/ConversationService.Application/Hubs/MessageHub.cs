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
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            try
            {
                await _sender.Send(new DisconnectDto());
            }
            catch (Exception)
            {
                return;
            }
        }

        public async Task CreateMessage(CreateMessageDto request)
        {
            try
            {
                await _sender.Send(request);
            }
            catch(Exception ex)
            {
                await Clients
                    .Caller
                    .SendAsync("messageCreationFailedNotification",new AppFailResponseDto(ex.Message));
                return;
            }
        }

        public async Task MarkNewMessagesAsReceived(MarkNewMessagesAsReceivedDto request)
        {
            try
            {
                await _sender.Send(request);
            }catch(Exception)
            {
                return;
            }
            
        }
        public async Task MarkNewMessagesAsViewed(MarkNewMessagesAsViewedDto request)
        {
            try
            {
                await _sender.Send(request);
            }catch(Exception)
            {
                return;
            }
        }

        public async Task MarkMessageAsReceived(MarkMessageAsReceivedDto request)
        {
            try
            {
                await _sender.Send(request);
            }
            catch (Exception)
            {
                return;
            }
        }
        public async Task MarkMessageAsViewed(MarkMessageAsViewedDto request)
        {
            IAppResponseDto response;
            try
            {
                await _sender.Send(request);
            }
            catch (Exception)
            {
                return;
            }
          
        }
        
        public async Task SendUserWrittingNotification(Guid userId)
        {
            var connection = await _context.UserConnections.FindAsync(userId);
            if(connection != null && connection.IsConnected) {
                await Clients.Client(connection.ConnectionId).SendAsync("userWritting");
            }
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
