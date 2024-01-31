using Models.Interfaces.Repositories;
using MediatR;
using Models.Dtos;
using Models.Entities;

namespace Commands
{
	public class DeleteCommandHandler : IRequestHandler<DeleteCategoryDto, AppResponseDto>
	{
		private readonly IRepository<Tag> _tags;

		public DeleteCommandHandler(IRepository<Tag> tags)
		{
			_tags = tags;
		}

		public async Task<AppResponseDto> Handle(DeleteCategoryDto request, CancellationToken cancellationToken)
		{
			var tag = await _tags.DbSet.FindAsync(request.Id, cancellationToken);
			_tags.DbSet.Remove(tag);
			return AppResponseDto.Success();
		}
	}
}
