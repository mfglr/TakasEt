using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using MediatR;

namespace Commands
{
	public class UpdateTagCommandHandler : IRequestHandler<UpdateTagDto, AppResponseDto>
	{

		private readonly IReadRepository<Tag> _tags;

		public UpdateTagCommandHandler(IReadRepository<Tag> tags)
		{
			_tags = tags;
		}

		public async Task<AppResponseDto> Handle(UpdateTagDto request, CancellationToken cancellationToken)
		{
			var tag = await _tags.GetByIdAsync((int)request.Id!,cancellationToken);
			tag!.Update(request.Name!);
			return AppResponseDto.Success();
		}
	}
}
