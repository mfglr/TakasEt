using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Handler.Queries
{
	public class GetChildrenQueryHandler : IRequestHandler<GetChildren, AppResponseDto>
	{
		private readonly IRepository<Comment> _comments;
		private readonly IMapper _mapper;

		public GetChildrenQueryHandler(IRepository<Comment> comments, IMapper mapper)
		{
			_comments = comments;
			_mapper = mapper;
		}

		public async Task<AppResponseDto> Handle(GetChildren request, CancellationToken cancellationToken)
		{
			var comments = await _comments
				.DbSet
				.Include(x => x.User)
				.Include(x => x.UsersWhoLiked)
				.Where(x => x.ParentId == request.ParentId && x.CreatedDate < request.getQueryDate())
				.OrderByDescending(x => x.CreatedDate)
				.Skip(request.Skip)
				.Take(request.Take)
				.ToCommentResponseDto()
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success(_mapper.Map<List<CommentResponseDto>>(comments));
		}
	}
}
