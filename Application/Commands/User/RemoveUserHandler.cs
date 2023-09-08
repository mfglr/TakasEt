using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands
{
	public class RemoveUserHandler : IRequestHandler<RemoveUserRequestDto, NoContentResponseDto>
	{
		private readonly UserManager<User> _users;
		private readonly IRepository<Comment> _comments;
		private readonly RecursiveRepositoryOptions _option;
		public RemoveUserHandler(UserManager<User> users, RecursiveRepositoryOptions option, IRepository<Comment> comments)
		{
			_users = users;
			_option = option;
			_comments = comments;
		}

		public async Task<NoContentResponseDto> Handle(RemoveUserRequestDto request, CancellationToken cancellationToken)
		{
			var user = await _users.Users
				.Include(x => x.Articles)
				.ThenInclude(x => x.Comments)
				.ThenIncludeChildrenByRecursive(_option.Depth)
				.SingleOrDefaultAsync(x => x.Id == request.Id);
			
			foreach (var article in user.Articles)
				_comments.DbSet.RemoveRangeRecursive(article.Comments);
			await _users.DeleteAsync(user);

			return new NoContentResponseDto();
		}
	}
}
