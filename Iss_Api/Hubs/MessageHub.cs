using MediatR;
using Microsoft.AspNetCore.SignalR;
using Models.Dtos.Conversation;

namespace Iss_Api.Hubs
{
	public class MessageHub : Hub
	{

		private readonly ISender _sender;

		public MessageHub(ISender sender)
		{
			_sender = sender;
		}

		public async Task AddUserSignalRState(int userId)
		{
			await Clients.Caller.SendAsync("RecieveConnectionId", Context.ConnectionId);
			await _sender.Send(new AddUserSignalRStateDto(userId, Context.ConnectionId));
		}
		
	}
}
