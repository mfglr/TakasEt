using Application.Dtos;
using Application.Entities;
using Application.Helpers;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.ValueObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Commands
{
	public class AddUserImageCommandHandler : IRequestHandler<AddUserImageDto, AppResponseDto>
	{
		private readonly IBlobService _blobService;
		private readonly IRepository<User> _users;

		public AddUserImageCommandHandler(IBlobService blobService, IRepository<User> users)
		{
			_blobService = blobService;
			_users = users;
		}

		public async Task<AppResponseDto> Handle(AddUserImageDto request, CancellationToken cancellationToken)
		{
			var user = await _users.DbSet.Include(x => x.UserImages).FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);
			var blobName = CreateUniqFileName.RunHelper(request.Extention!);
			await _blobService.UploadAsync(request.Stream!, blobName, ContainerName.UserImage.Value,cancellationToken);
			user!.AddUserImage(blobName, request.Extention!);
			return AppResponseDto.Success();
		}
	}
}
