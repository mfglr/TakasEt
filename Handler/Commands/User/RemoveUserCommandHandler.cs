using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Exceptions;
using Application.Extentions;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Handler.Commands
{
	public class RemoveUserCommandHandler : IRequestHandler<RemoveUserRequestDto, AppResponseDto>
	{
		private readonly UserManager<User> _users;
		private readonly IRepository<Comment> _comments;
		public RemoveUserCommandHandler(UserManager<User> users, IRepository<Comment> comments)
		{
			_users = users;
			_comments = comments;
		}

		public async Task<AppResponseDto> Handle(RemoveUserRequestDto request, CancellationToken cancellationToken)
		{
			var user = await _users.Users
				.Include(x => x.Posts)
				.ThenInclude(x => x.Comments)
				.ThenIncludeChildrenByRecursive(Comment.Depth)
				.SingleOrDefaultAsync(x => x.Id == request.Id,cancellationToken);
			if (user == null) throw new UserNotFoundException();
			foreach (var post in user.Posts)
				_comments.DbSet.RemoveRangeRecursive(post.Comments);
			await _users.DeleteAsync(user);
			return AppResponseDto.Success();
		}
	}
}
