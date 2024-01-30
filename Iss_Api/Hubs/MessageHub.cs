using Application.Interfaces;
using Application.Interfaces.Repositories;
using Microsoft.AspNetCore.SignalR;
using Models.Entities;
using Models.Exceptions;

namespace Iss_Api.Hubs
{
	public class MessageHub : Hub
	{

		private IRepository<User> _users;
		private IUnitOfWork _unitOfWork;

		public MessageHub(IRepository<User> users, IUnitOfWork unitOfWork)
		{
			_users = users;
			_unitOfWork = unitOfWork;
		}

		public async Task SetMessageHubState(int userId)
		{
			var user = await _users.DbSet.FindAsync(userId);
			if (user == null) throw new UserNotFoundException();
			user.SetMessageHubState(Context.ConnectionId);
			await _unitOfWork.CommitAsync();
		}
		
	}
}
