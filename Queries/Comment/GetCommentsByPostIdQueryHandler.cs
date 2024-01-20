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
	public class GetCommentsByPostIdQueryHandler : IRequestHandler<GetCommentsByPostIdDto, AppResponseDto>
	{
		private readonly IRepository<Comment> _comments;

		public GetCommentsByPostIdQueryHandler(IRepository<Comment> comments)
		{
			_comments = comments;
		}

		public async Task<AppResponseDto> Handle(GetCommentsByPostIdDto request, CancellationToken cancellationToken)
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
				.ToCommentResponseDto(request.LoggedInUserId)
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success(comments);
		}
	}
}
