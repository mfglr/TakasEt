using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using MediatR;

namespace Commands
{
	public class AddTagCommandHandler : IRequestHandler<AddTagDto, AppResponseDto>
	{
		private readonly IWriteRepository<Tag> _tags;

		public AddTagCommandHandler(IWriteRepository<Tag> tags)
		{
			_tags = tags;
		}

		public async Task<AppResponseDto> Handle(AddTagDto request, CancellationToken cancellationToken)
		{
			var tag = new Tag(request.Name!);
			return AppResponseDto.Success(  await _tags.CreateAsync(tag, cancellationToken) );
		}
	}
}
