using Application.Dtos;
using Application.Entities;
using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries
{
    public class GetActiveProfileImageByIdQueryHandler : IRequestHandler<GetActiveProfileImageByIdRequestDto, byte[]>
    {
        private readonly IFileWriterService _writerService;
        private readonly IBlobService _blobService;
        private readonly UserManager<User> _userManager;

		public GetActiveProfileImageByIdQueryHandler(IFileWriterService writerService, IBlobService blobService, IRepository<ProfileImage> profileImages, UserManager<User> userManager)
		{
			_writerService = writerService;
			_blobService = blobService;
			_userManager = userManager;
		}

		public async Task<byte[]> Handle(GetActiveProfileImageByIdRequestDto request, CancellationToken cancellationToken)
        {
            var user = await _userManager
                .Users
                .Include(x => x.ProfilePictures)
                .FirstOrDefaultAsync(x => x.Id == request.UserId);
            if (user == null) throw new UserNotFoundException();
            var image = user.ProfilePictures.FirstOrDefault(x => x.IsActive);
            if (image == null)
            {
                byte[] noImageFile;
                if (user.Gender == null)
					noImageFile = await File.ReadAllBytesAsync("Images/noProfile.jpg");
				else if ((bool)user.Gender)
                    noImageFile = await File.ReadAllBytesAsync("Images/noProfileMan.jpg");
                else
                    noImageFile = await File.ReadAllBytesAsync("Images/noProfileWoman.jpg");
				noImageFile = await File.ReadAllBytesAsync("Images/noImage.jpg");
                await _writerService.WriteFileAsync(noImageFile, "jpg", cancellationToken);
                return _writerService.Bytes;
            }
            var profileImage = await _blobService.DownloadAsync(image.BlobName, image.ContainerName, cancellationToken);
            await _writerService.WriteFileAsync(profileImage, image.Extention, cancellationToken);
            return _writerService.Bytes;
        }
    }
}
