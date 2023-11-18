using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Handler.Queries
{
	public class GetCommentsByPostIdQueryHandler : IRequestHandler<GetCommentsByPostId, AppResponseDto>
	{
		private readonly IRepository<Comment> _comments;

		public GetCommentsByPostIdQueryHandler(IRepository<Comment> comments)
		{
			_comments = comments;
		}

		public async Task<AppResponseDto> Handle(GetCommentsByPostId request, CancellationToken cancellationToken)
		{
			var comments = await _comments
				.DbSet
				.AsNoTracking()
				.Include(x => x.User)
				.ThenInclude(x => x.ProfileImages)
				.Include(x => x.Children)
				.Include(x => x.UsersWhoLiked)
				.Where(x => x.PostId == request.PostId && x.CreatedDate < request.getQueryDate())
				.OrderByDescending(x => x.CreatedDate)
				.Skip(request.Skip)
				.Take(request.Take)
				.ToCommentResponseDto()
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success(comments);
		}
	}
}
