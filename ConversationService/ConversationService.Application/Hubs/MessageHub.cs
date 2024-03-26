using ConversationService.Application.Dtos;
using ConversationService.Infrastructure;
using ConversationService.SignalR.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using System.Net;

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

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await _sender.Send(new DisconnectDto());
        }
        public async Task<IAppResponseDto> Connect()
        {
            return await _sender.Send(new ConnectDto() { ConnectionId = Context.ConnectionId });
        }
        public async Task<IAppResponseDto> GetNewMessages(GetNewMessagesDto request)
        {
            return await _sender.Send(request);
        }
        public async Task<IAppResponseDto> CreateMessage(CreateMessageDto request)
        {
            return await _sender.Send(request);
        }
        public async Task<IAppResponseDto> MarkMessageAsReceived(MarkMessageAsReceivedDto request)
        {
            return await _sender.Send(request);
        }
        public async Task MarkMessageAsViewed(MarkMessageAsViewedDto request)
        {
            await _sender.Send(request);
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
                    .SendAsync("LikeMessageFailed", new AppFailResponseDto(ex.Message,HttpStatusCode.InternalServerError));
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
