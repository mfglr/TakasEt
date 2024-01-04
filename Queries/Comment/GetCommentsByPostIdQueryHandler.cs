using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Queries
{
	public class GetCommentsByPostIdQueryHandler : IRequestHandler<GetCommentsByPostId, AppResponseDto>
	{
		private readonly IRepository<Comment> _comments;
		private readonly LoggedInUser _loggeddInUser;

		public GetCommentsByPostIdQueryHandler(IRepository<Comment> comments, LoggedInUser loggeddInUser)
		{
			_comments = comments;
			_loggeddInUser = loggeddInUser;
		}

		public async Task<AppResponseDto> Handle(GetCommentsByPostId request, CancellationToken cancellationToken)
		{
			var comments = await _comments
				.DbSet
				.AsNoTracking()
				.Include(x => x.User)
				.ThenInclude(x => x.UserImages)
				.Include(x => x.Children)
				.Include(x => x.UsersWhoLiked)
				.Where(x => x.PostId == request.PostId)
				.ToPage(request)
				.ToCommentResponseDto(_loggeddInUser.UserId)
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success(comments);
		}
	}
}
