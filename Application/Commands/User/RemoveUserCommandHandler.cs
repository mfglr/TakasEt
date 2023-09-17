using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Exceptions;
using Application.Extentions;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands
{
	public class RemoveUserCommandHandler : IRequestHandler<RemoveUserRequestDto, AppResponseDto<NoContentResponseDto>>
	{
		private readonly UserManager<User> _users;
		private readonly IRepository<Comment> _comments;
		private readonly RecursiveRepositoryOptions _option;
		public RemoveUserCommandHandler(UserManager<User> users, RecursiveRepositoryOptions option, IRepository<Comment> comments)
		{
			_users = users;
			_option = option;
			_comments = comments;
		}

		public async Task<AppResponseDto<NoContentResponseDto>> Handle(RemoveUserRequestDto request, CancellationToken cancellationToken)
		{
			var user = await _users.Users
				.Include(x => x.Posts)
				.ThenInclude(x => x.Comments)
				.ThenIncludeChildrenByRecursive(_option.Depth)
				.SingleOrDefaultAsync(x => x.Id == request.Id);
			if (user == null) throw new UserNotFoundException();
			foreach (var post in user.Posts)
				_comments.DbSet.RemoveRangeRecursive(post.Comments);
			await _users.DeleteAsync(user);
			return AppResponseDto<NoContentResponseDto>.Success(new NoContentResponseDto());
		}
	}
}
