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
				.Where(x => x.ParentId == request.ParentId)
				.ToPage(request)
				.Select(
					x => new CommentResponseDto()
					{
						Content = x.Content,
						CountOfLikes = x.UsersWhoLiked.Count,
						CreatedDate = x.CreatedDate,
						Id = x.Id,
						ParentId = x.ParentId,
						PostId = x.PostId,
						UpdatedDate = x.UpdatedDate,
						UserId = x.UserId,
						UserName = x.User.UserName!
					}
				)
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success(_mapper.Map<List<CommentResponseDto>>(comments));
		}
	}
}
