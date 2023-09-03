using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Commands
{
	public class AddCommentHandler : IRequestHandler<AddCommentRequestDto, AddCommentResponseDto>
	{

		private readonly IRecursiveRepository<Comment> _comments;
		private readonly IMapper _mapper;

		public AddCommentHandler(IRecursiveRepository<Comment> comments, IMapper mapper)
		{
			_comments = comments;
			_mapper = mapper;
		}

		public async Task<AddCommentResponseDto> Handle(AddCommentRequestDto request, CancellationToken cancellationToken)
		{
			var comment = new Comment(request.ParentId,request.ArticleId, request.UserId, request.Content);
			await _comments.AddAsync(comment);
			return _mapper.Map<AddCommentResponseDto>(comment);
		}
	}
}
