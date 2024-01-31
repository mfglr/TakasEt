using Models.Interfaces.Repositories;
using Models.Interfaces.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Models.Dtos;
using Models.Entities;

namespace Queries
{
	public class GetUserImageQueryHandler : IRequestHandler<GetUserImage, byte[]>
	{
		private readonly IRepository<UserImage> _userImages;
		private readonly IBlobService _blobService;

		public GetUserImageQueryHandler(IRepository<UserImage> userImages, IBlobService blobService)
		{
			_userImages = userImages;
			_blobService = blobService;
		}

		public async Task<byte[]> Handle(GetUserImage request, CancellationToken cancellationToken)
		{
			var userImage = await _userImages
				.DbSet
				.AsNoTracking()
				.FirstAsync(x => x.Id == request.Id,cancellationToken);
			return await _blobService.DownloadAsync(userImage.BlobName, userImage.ContainerName, cancellationToken);
		}
	}
}
