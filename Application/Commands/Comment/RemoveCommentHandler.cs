using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands
{
	public class RemoveCommentHandler : IRequestHandler<RemoveCommentRequestDto, NoContentResponseDto>
	{
		private readonly IRepository<Comment> _comments;
		private readonly RecursiveRepositoryOptions _option;

		public RemoveCommentHandler(IRepository<Comment> comments, RecursiveRepositoryOptions option)
		{
			_comments = comments;
			_option = option;
		}

		public async Task<NoContentResponseDto> Handle(RemoveCommentRequestDto request, CancellationToken cancellationToken)
		{
			var comment = await _comments.DbSet
				.IncludeChildrenByRecursive(_option.Depth)
				.FirstOrDefaultAsync(x => x.Id == request.Id);
			if (comment == null) throw new Exception("hata");
			_comments.DbSet.RemoveRecursive(comment);
			return new NoContentResponseDto();
		}
	}
}
