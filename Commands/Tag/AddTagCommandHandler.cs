using Models.Interfaces.Repositories;
using MediatR;
using Models.Dtos;
using Models.Entities;

namespace Commands
{
	public class AddTagCommandHandler : IRequestHandler<AddTagDto, AppResponseDto>
	{
		private readonly IRepository<Tag> _tags;

		public AddTagCommandHandler(IRepository<Tag> tags)
		{
			_tags = tags;
		}

		public async Task<AppResponseDto> Handle(AddTagDto request, CancellationToken cancellationToken)
		{
			var tag = new Tag(request.Name!);
			var entity = (await _tags.DbSet.AddAsync(tag, cancellationToken)).Entity;
			return AppResponseDto.Success(entity);
		}
	}
}
