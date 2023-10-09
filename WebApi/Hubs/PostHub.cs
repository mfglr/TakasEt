using Application.Entities;
using Application.Interfaces.Repositories;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Hubs
{
	public class PostHub : Hub
	{
		private readonly IRepository<Post> _posts;

		public PostHub(IRepository<Post> posts)
		{
			_posts = posts;
		}

		public async Task SendCountOfViewsAndLikes(Guid postId)
		{
			var data = await _posts
				.DbSet
				.Include(x => x.UsersWhoLiked)
				.Include(x => x.UsersWhoViewed)
				.Where(x => x.Id == postId)
				.Select(
					x => new
					{
						countOfLikes = x.UsersWhoLiked.Count,
						countOfViews = x.UsersWhoViewed.Count
					}
				)
				.FirstOrDefaultAsync();
			await Clients.Caller.SendAsync("recieveCountOfViewsAndLikes",data);
		}
	}
}
