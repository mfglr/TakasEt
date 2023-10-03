using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.ValueObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands
{
	public class AddProfileImageCommadHandler : IRequestHandler<AddProfileImageRequestDto, AppResponseDto>
	{

		private readonly IBlobService _blobService;
		private readonly IRepository<ProfileImage> _profileImages;

		public AddProfileImageCommadHandler(IBlobService blobService, IRepository<ProfileImage> profileImages)
		{
			_blobService = blobService;
			_profileImages = profileImages;
		}

		public async Task<AppResponseDto> Handle(AddProfileImageRequestDto request, CancellationToken cancellationToken)
		{
			var prevProfileImage = await _profileImages
				.DbSet
				.FirstOrDefaultAsync(x => x.IsActive && x.Id == request.UserId);
			if(prevProfileImage != null)
				prevProfileImage.Deactivate();
			var blobName = Helpers.CreateUniqFileName.RunHelper(request.UserId, request.Extention);
			var nextProfileImage = new ProfileImage(true, request.UserId, blobName, request.Extention);
			await _profileImages.DbSet.AddAsync(nextProfileImage, cancellationToken);
			await _blobService.UploadAsync(request.Stream, blobName, ContainerName.ProfileImage.Value,cancellationToken);
			return AppResponseDto.Success();
		}
	}
}
