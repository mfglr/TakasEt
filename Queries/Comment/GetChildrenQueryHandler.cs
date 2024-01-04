using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Queries
{
	public class GetChildrenQueryHandler : IRequestHandler<GetChildren, AppResponseDto>
	{
		private readonly IRepository<Comment> _comments;
		private readonly IMapper _mapper;
		private readonly LoggedInUser _loggedInUser;

		public GetChildrenQueryHandler(IRepository<Comment> comments, IMapper mapper, LoggedInUser loggedInUser)
		{
			_comments = comments;
			_mapper = mapper;
			_loggedInUser = loggedInUser;
		}

		public async Task<AppResponseDto> Handle(GetChildren request, CancellationToken cancellationToken)
		{
			var comments = await _comments
				.DbSet
				.Include(x => x.User)
				.Include(x => x.UsersWhoLiked)
				.Where(x => x.ParentId == request.ParentId)
				.ToPage(request)
				.ToCommentResponseDto(_loggedInUser.UserId)
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success(_mapper.Map<List<CommentResponseDto>>(comments));
		}
	}
}
