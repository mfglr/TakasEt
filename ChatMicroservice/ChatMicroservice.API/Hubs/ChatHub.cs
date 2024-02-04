using ChatMicroservice.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace ChatMicroservice.API.Hubs
{
	public class ChatHub : Hub
	{
		private readonly ISender _sender;
		public ChatHub(ISender sender) => _sender = sender;

		public async Task Connect(ConnectDto request,CancellationToken cancellationToken)
		{
			var response = await _sender.Send(request);
			await Clients.Caller.SendAsync("connectionSuccessNotification", response, cancellationToken);
		}

		public async Task Disconnect(DisconnectDto request, CancellationToken cancellationToken)
		{
			var response = await _sender.Send(request);
			await Clients.Caller.SendAsync("disconnectionSuccessNotification", response, cancellationToken);
		}

		public async Task SaveMessage(SendMessageDto request,CancellationToken cancellationToken)
		{
			var response = await _sender.Send(request);
			await Clients.Caller.SendAsync("savedMessageSuccessNotification", response, cancellationToken);
		}
	}

	
}
