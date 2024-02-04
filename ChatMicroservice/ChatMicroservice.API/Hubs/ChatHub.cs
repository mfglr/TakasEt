using ChatMicroservice.Application.Dtos;
using ChatMicroservice.Application.Dtos.Message;
using ChatMicroservice.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace ChatMicroservice.API.Hubs
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

		public async Task Connect(ConnectDto request,CancellationToken cancellationToken)
		{
			var response = await _sender.Send(request, cancellationToken);
			await Clients.Caller.SendAsync("connectionSuccessNotification", response, cancellationToken);
		}

		public async Task Disconnect(DisconnectDto request, CancellationToken cancellationToken)
		{
			var response = await _sender.Send(request, cancellationToken);
			await Clients.Caller.SendAsync("disconnectionSuccessNotification", response, cancellationToken);
		}

		public async Task SendMessageToUser(SaveMessageDto request,CancellationToken cancellationToken)
		{
			//save message
			var response = await _sender.Send(request, cancellationToken);
			await Clients.Caller.SendAsync("savedMessageSuccessNotification", response, cancellationToken);

			//send the message if receiver is connected;
			var receiverConnection = await _context
				.Connections
				.FirstOrDefaultAsync(x => x.UserId == request.ReceiverId, cancellationToken);

			if (receiverConnection != null && receiverConnection.Connected)
				await Clients.Client(receiverConnection.ConnectionId).SendAsync("getMessage",response,cancellationToken);
		}

		public async Task MarkMessageAsReceived(MarkMessageAsReceivedDto request,CancellationToken cancellationToken)
		{
			var response = await _sender.Send(request, cancellationToken);

			var senderConnection = await _context
				.Connections
				.FirstOrDefaultAsync(x => x.UserId == request.SenderId, cancellationToken);
			
			if (senderConnection != null && senderConnection.Connected)
				await Clients.Client(senderConnection.ConnectionId).SendAsync("receivedMessageSuccessNotification", response);
		}
		
	}

	
}
