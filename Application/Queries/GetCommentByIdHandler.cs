using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries
{
	public class GetCommentByIdHandler : IRequestHandler<GetCommentByIdRequestDto, CommentResponseDto>
	{

		private readonly IRepository<Comment> _comments;
		private readonly IMapper _mapper;
		private readonly RecursiveRepositoryOptions _option;
		public GetCommentByIdHandler(IRepository<Comment> comments, IMapper mapper, RecursiveRepositoryOptions option)
		{
			_comments = comments;
			_mapper = mapper;
			_option = option;
		}

		public async Task<CommentResponseDto> Handle(GetCommentByIdRequestDto request, CancellationToken cancellationToken)
		{
			var comment = await _comments.DbSet
				.AsNoTracking()
				.IncludeChildrenByRecursive(3)
				.FirstOrDefaultAsync(x => x.Id == request.Id);
			return _mapper.Map<CommentResponseDto>( comment );
		}
	}
}
