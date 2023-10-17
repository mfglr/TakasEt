using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries
{
	public class IsCommentLikedQueryHandler : IRequestHandler<IsCommentLiked, AppResponseDto>
	{
		private readonly IRepository<UserCommentLiking> _likes;
		private readonly LoggedInUser _loggedInUser;

		public IsCommentLikedQueryHandler(IRepository<UserCommentLiking> likes, LoggedInUser loggedInUser)
		{
			_likes = likes;
			_loggedInUser = loggedInUser;
		}

		public async Task<AppResponseDto> Handle(IsCommentLiked request, CancellationToken cancellationToken)
		{
			var anyRecord = await _likes
				.DbSet
				.AnyAsync(
					x =>
						x.UserId == _loggedInUser.UserId &&
						x.Id == request.CommentId
				);
			return AppResponseDto.Success(anyRecord);
		}
	}
}
