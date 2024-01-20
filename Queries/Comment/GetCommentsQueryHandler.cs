using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Queries
{
	public class GetCommentsQueryHandler : IRequestHandler<GetCommentsDto, AppResponseDto>
	{
		private readonly IRepository<Comment> _comments;

		public GetCommentsQueryHandler(IRepository<Comment> comments)
		{
			_comments = comments;
		}

		public async Task<AppResponseDto> Handle(GetCommentsDto request, CancellationToken cancellationToken)
		{
			var comments = await _comments
				.DbSet
				.AsNoTracking()
				.Include(x => x.User)
				.ThenInclude(x => x.UserImages)
				.Include(x => x.Children)
				.Include(x => x.UsersWhoLiked)
				.ToPage(request)
				.ToCommentResponseDto(request.LoggedInUserId)
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success(comments);
		}
	}
}
