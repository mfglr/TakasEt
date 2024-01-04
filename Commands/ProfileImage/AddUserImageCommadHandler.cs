using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.ValueObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Commands
{
    public class AddUserImageCommadHandler : IRequestHandler<AddUserImage, AppResponseDto>
    {

        private readonly IBlobService _blobService;
        private readonly IRepository<UserImage> _userImages;
        private readonly LoggedInUser _loggedInUser;

        public AddUserImageCommadHandler(IBlobService blobService, IRepository<UserImage> userImages, LoggedInUser loggedInUser)
        {
            _blobService = blobService;
            _userImages = userImages;
            _loggedInUser = loggedInUser;
        }

        public async Task<AppResponseDto> Handle(AddUserImage request, CancellationToken cancellationToken)
        {
            var prevProfileImage = await _userImages
                .DbSet
                .FirstOrDefaultAsync(x => x.IsActive && x.UserId == _loggedInUser.UserId);
            if (prevProfileImage != null)
                prevProfileImage.Deactivate();
            var blobName = Application.Helpers.CreateUniqFileName.RunHelper(request.Extention);
            var nextProfileImage = new UserImage(true, _loggedInUser.UserId, blobName, request.Extention);
            await _userImages.DbSet.AddAsync(nextProfileImage, cancellationToken);
            await _blobService.UploadAsync(request.Stream, blobName, ContainerName.ProfileImage.Value, cancellationToken);
            return AppResponseDto.Success();
        }
    }
}
