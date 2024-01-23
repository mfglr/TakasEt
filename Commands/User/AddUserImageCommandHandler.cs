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
		private readonly IImageService _imageService;

		public AddUserImageCommandHandler(IBlobService blobService, IRepository<User> users, IImageService imageService)
		{
			_blobService = blobService;
			_users = users;
			_imageService = imageService;
		}

		public async Task<AppResponseDto> Handle(AddUserImageDto request, CancellationToken cancellationToken)
		{

			var user = await _users
				.DbSet
				.Include(x => x.UserImages)
				.FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);

			string blobName = CreateUniqFileName.RunHelper(request.Extention!);
			Dimension dimension = _imageService.GetDimension(request.Stream!);
			
			await _blobService.UploadAsync(request.Stream!, blobName, ContainerName.UserImage,cancellationToken);
			user!.AddUserImage(blobName, request.Extention!,dimension);
			
			return AppResponseDto.Success();
		}
	}
}
