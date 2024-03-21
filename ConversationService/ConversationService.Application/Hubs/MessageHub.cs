using ConversationService.Application.Dtos;
using ConversationService.Infrastructure;
using ConversationService.SignalR.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;

namespace ConversationService.Application.Hubs
{
    [Authorize(Roles = "user")]
    public class MessageHub : Hub
    {
        private readonly ISender _sender;
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

        public MessageHub(ISender sender, AppDbContext context, IHttpContextAccessor contextAccessor)
        {
            _sender = sender;
            _context = context;
            _contextAccessor = contextAccessor;
        }

        public override async Task OnConnectedAsync()
        {
            _contextAccessor.HttpContext = Context.GetHttpContext();
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
            _contextAccessor.HttpContext = Context.GetHttpContext();
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
            _contextAccessor.HttpContext = Context.GetHttpContext();
            try
            {
                await _sender.Send(request);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                await Clients
                    .Caller
                    .SendAsync("messageCreationFailedNotification",new AppFailResponseDto(ex.Message));
                return;
            }
        }

        public async Task MarkNewMessagesAsReceived(MarkNewMessagesAsReceivedDto request)
        {
            _contextAccessor.HttpContext = Context.GetHttpContext();
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
            _contextAccessor.HttpContext = Context.GetHttpContext();
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
            _contextAccessor.HttpContext = Context.GetHttpContext();
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
            _contextAccessor.HttpContext = Context.GetHttpContext();
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
            _contextAccessor.HttpContext = Context.GetHttpContext();
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
