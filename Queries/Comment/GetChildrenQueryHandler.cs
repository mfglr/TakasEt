using Application.Extentions;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Models.Dtos;
using Models.Entities;

namespace Queries
{
	public class GetChildrenQueryHandler : IRequestHandler<GetChildrenDto, AppResponseDto>
	{
		private readonly IRepository<Comment> _comments;
		private readonly IMapper _mapper;

		public GetChildrenQueryHandler(IRepository<Comment> comments, IMapper mapper)
		{
			_comments = comments;
			_mapper = mapper;
		}

		public async Task<AppResponseDto> Handle(GetChildrenDto request, CancellationToken cancellationToken)
		{
			var comments = await _comments
				.DbSet
				.Include(x => x.User)
				.Include(x => x.UsersWhoLiked)
				.Where(x => x.ParentId == request.ParentId)
				.ToPage(request)
				.ToCommentResponseDto(request.LoggedInUserId)
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success(_mapper.Map<List<CommentResponseDto>>(comments));
		}
	}
}
