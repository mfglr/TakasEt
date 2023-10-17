using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries
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
				.Include(x => x.Children)
				.Where(x => x.PostId == request.PostId)
				.Select(
					x => new CommentResponseDto()
					{
						Content = x.Content,
						CountOfChildren = x.Children.Count,
						CreatedDate = x.CreatedDate,
						Id = x.Id,
						PostId = x.PostId,
						ParentId = x.ParentId,
						UpdatedDate = x.UpdatedDate,
						UserId = x.UserId,
						UserName = x.User.UserName!
					}
				)
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success(comments);
		}
	}
}
