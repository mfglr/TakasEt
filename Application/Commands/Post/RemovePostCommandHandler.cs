using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Exceptions;
using Application.Extentions;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands
{
	public class RemovePostCommandHandler : IRequestHandler<RemovePost, AppResponseDto>
	{
		private readonly IRepository<Post> _posts;
		private readonly IRepository<Comment> _comments;

		public RemovePostCommandHandler(IRepository<Post> post, IRepository<Comment> comments)
		{
			_posts = post;
			_comments = comments;
		}

		public async Task<AppResponseDto> Handle(RemovePost request, CancellationToken cancellationToken)
		{
			var post = await _posts
				.DbSet
				.Include(x => x.User)
				.Include(x => x.Comments)
				.ThenIncludeChildrenByRecursive(Comment.Depth)
				.FirstOrDefaultAsync(x => x.Id == request.PostId, cancellationToken);
			_comments.DbSet.RemoveRangeRecursive(post.Comments);
			_posts.DbSet.Remove(post);
			return AppResponseDto.Success();
		}
	}
}
