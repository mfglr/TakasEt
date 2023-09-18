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
	public class RemovePostCommandHandler : IRequestHandler<RemovePostRequestDto, AppResponseDto<NoContentResponseDto>>
	{
		private readonly IRepository<Post> _posts;
		private readonly IRepository<Comment> _comments;
		private readonly RecursiveRepositoryOptions _option;
		private readonly LoggedInUser _loggedInUser;

		public RemovePostCommandHandler(IRepository<Post> post, RecursiveRepositoryOptions option, IRepository<Comment> comments, LoggedInUser loggedInUser)
		{
			_posts = post;
			_option = option;
			_comments = comments;
			_loggedInUser = loggedInUser;
		}

		public async Task<AppResponseDto<NoContentResponseDto>> Handle(RemovePostRequestDto request, CancellationToken cancellationToken)
		{
			var post = await _posts
				.DbSet
				.Include(x => x.User)
				.Include(x => x.Comments)
				.ThenIncludeChildrenByRecursive(_option.Depth)
				.FirstOrDefaultAsync(x => x.Id == request.PostId);
			if (post == null) throw new PostNotFoundException();
			if (post.User.Id != _loggedInUser.UserId) throw new UnmatchedRequestException("Remove-Post");
			_comments.DbSet.RemoveRangeRecursive(post.Comments);
			_posts.DbSet.Remove(post);
			return AppResponseDto<NoContentResponseDto>.Success(new NoContentResponseDto());
		}
	}
}
