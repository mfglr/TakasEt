using Application.Configurations;
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
        private readonly LoggedInUser _loggedInUser;

        public AddProfileImageCommadHandler(IBlobService blobService, IRepository<ProfileImage> profileImages, LoggedInUser loggedInUser)
        {
            _blobService = blobService;
            _profileImages = profileImages;
            _loggedInUser = loggedInUser;
        }

        public async Task<AppResponseDto> Handle(AddProfileImageRequestDto request, CancellationToken cancellationToken)
        {
            var prevProfileImage = await _profileImages
                .DbSet
                .FirstOrDefaultAsync(x => x.IsActive && x.UserId == _loggedInUser.UserId);
            if (prevProfileImage != null)
                prevProfileImage.Deactivate();
            var blobName = Helpers.CreateUniqFileName.RunHelper(_loggedInUser.UserId, request.Extention);
            var nextProfileImage = new ProfileImage(true, _loggedInUser.UserId, blobName, request.Extention);
            await _profileImages.DbSet.AddAsync(nextProfileImage, cancellationToken);
            await _blobService.UploadAsync(request.Stream, blobName, ContainerName.ProfileImage.Value, cancellationToken);
            return AppResponseDto.Success();
        }
    }
}
