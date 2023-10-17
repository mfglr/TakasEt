using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Commands
{
	public class AddCommentHandler : IRequestHandler<AddComment, AppResponseDto>
	{

		private readonly IRepository<Comment> _comments;
		private readonly IMapper _mapper;

		public AddCommentHandler(IRepository<Comment> comments, IMapper mapper)
		{
			_comments = comments;
			_mapper = mapper;
		}

		public async Task<AppResponseDto> Handle(AddComment request, CancellationToken cancellationToken)
		{
			var comment = new Comment(request.ParentId,request.PostId, request.UserId, request.Content);
			await _comments
				.DbSet
				.AddAsync(comment,cancellationToken);
			return AppResponseDto.Success(
				_mapper.Map<CommentResponseDto>(comment)
				);
		}
	}
}
