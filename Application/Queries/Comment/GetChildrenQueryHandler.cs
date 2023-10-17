using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries
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
				.Include(x => x.Children)
				.Where(x => x.ParentId == request.ParentId)
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success(_mapper.Map<List<CommentResponseDto>>(comments));
		}
	}
}
