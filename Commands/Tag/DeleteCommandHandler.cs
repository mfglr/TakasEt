﻿using Application.Interfaces.Repositories;
using MediatR;
using Models.Dtos;
using Models.Entities;

namespace Commands
{
	public class DeleteCommandHandler : IRequestHandler<DeleteCategoryDto, AppResponseDto>
	{
		private readonly IWriteRepository<Tag> _tags;

		public DeleteCommandHandler(IWriteRepository<Tag> tags)
		{
			_tags = tags;
		}

		public async Task<AppResponseDto> Handle(DeleteCategoryDto request, CancellationToken cancellationToken)
		{
			await _tags.DeleteAsync(request.Id, cancellationToken);
			return AppResponseDto.Success();
		}
	}
}