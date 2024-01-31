using Models.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Models.Dtos;
using Models.Entities;

namespace Iss_Api.Hubs
{
	public class MessageHub : Hub
	{

		private readonly ISender _sender;
		private readonly IRepository<User> _users;

		public MessageHub(ISender sender, IRepository<User> users)
		{
			_sender = sender;
			_users = users;
		}

		public async Task SetMessageHubState(SetMessageHubStateDto request)
		{
			await _sender.Send(request);
		}

		public async Task SaveMessage(SaveMessageDto request)
		{
			var response = await _sender.Send(request);
			await Clients.Caller.SendAsync("SavedMessageSuccess", response);
		}

	}
}
