using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands
{
	public class RemoveCommentHandler : IRequestHandler<RemoveCommentRequestDto, NoContentResponseDto>
	{

		private readonly IRecursiveRepository<Comment> _comments;

		public RemoveCommentHandler(IRecursiveRepository<Comment> comments)
		{
			_comments = comments;
		}

		public async Task<NoContentResponseDto> Handle(RemoveCommentRequestDto request, CancellationToken cancellationToken)
		{
			var comment = await _comments.Where(x => x.Id == request.Id).SingleOrDefaultAsync();
			if (comment == null) throw new Exception("hata");
			_comments.Remove(comment);
			return new NoContentResponseDto();
		}
	}
}
