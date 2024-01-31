using Models.Interfaces.Repositories;
using MediatR;
using Models.Dtos;
using Models.Entities;

namespace Commands
{
	public class UpdateTagCommandHandler : IRequestHandler<UpdateTagDto, AppResponseDto>
	{

		private readonly IRepository<Tag> _tags;

		public UpdateTagCommandHandler(IRepository<Tag> tags)
		{
			_tags = tags;
		}

		public async Task<AppResponseDto> Handle(UpdateTagDto request, CancellationToken cancellationToken)
		{
			var tag = await _tags
				.DbSet
				.FindAsync((int)request.Id!,cancellationToken);

			tag!.Update(request.Name!);
			return AppResponseDto.Success();
		}
	}
}
