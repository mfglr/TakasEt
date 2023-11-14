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

		public async Task SendCounts(List<int> postIds)
		{
			var counts = await _posts
				.DbSet
				.Include(x => x.UsersWhoLiked)
				.Include(x => x.UsersWhoViewed)
				.Include(x => x.Comments)
				.Where(x => postIds.Contains(x.Id))
				.Select(
					x => new
					{
						countOfLikes = x.UsersWhoLiked.Count,
						countOfViews = x.UsersWhoViewed.Count,
						countOfComments = x.Comments.Count
					}
				)
				.ToListAsync();
			await Clients.Caller.SendAsync("recieveCounts", counts);
		}
	}
}
