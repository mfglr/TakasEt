using Microsoft.AspNetCore.SignalR;

namespace Iss_Api.Hubs
{
	public class MessageHub : Hub
	{

		public async Task SendMessageAsync(string messageContent)
		{
			await Clients.All.SendAsync("ReceiveMessage", messageContent);
		}

		//public async Task<string> ReceiveMessageAsync()
		//{
		//	//return await Clients.All.SendAsync("")
		//}
	}
}
