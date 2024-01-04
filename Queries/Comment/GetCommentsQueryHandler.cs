using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Queries
{
	public class GetCommentsQueryHandler : IRequestHandler<GetComments, AppResponseDto>
	{
		private readonly LoggedInUser _loggedInUser;
		private readonly IRepository<Comment> _comments;

		public GetCommentsQueryHandler(IRepository<Comment> comments, LoggedInUser loggedInUser)
		{
			_comments = comments;
			_loggedInUser = loggedInUser;
		}

		public async Task<AppResponseDto> Handle(GetComments request, CancellationToken cancellationToken)
		{
			var comments = await _comments
				.DbSet
				.AsNoTracking()
				.Include(x => x.User)
				.ThenInclude(x => x.UserImages)
				.Include(x => x.Children)
				.Include(x => x.UsersWhoLiked)
				.ToPage(request)
				.ToCommentResponseDto(_loggedInUser.UserId)
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success(comments);
		}
	}
}
