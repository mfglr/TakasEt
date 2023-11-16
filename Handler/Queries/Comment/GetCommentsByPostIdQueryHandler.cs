using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Handler.Queries
{
	public class GetCommentsByPostIdQueryHandler : IRequestHandler<GetCommentsByPostId, byte[]>
	{
		private readonly IRepository<Comment> _comments;
		private readonly IFileWriterService _writeService;

		public GetCommentsByPostIdQueryHandler(IRepository<Comment> comments, IFileWriterService writeService)
		{
			_comments = comments;
			_writeService = writeService;
		}

		public async Task<byte[]> Handle(GetCommentsByPostId request, CancellationToken cancellationToken)
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
			await _writeService.WriteCommentsAsync(comments, cancellationToken);
			return _writeService.Bytes;
		}
	}
}
