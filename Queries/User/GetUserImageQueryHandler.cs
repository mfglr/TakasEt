using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
				.FirstOrDefaultAsync(x => x.Id == request.Id);
			return await _blobService.DownloadAsync(userImage.BlobName, userImage.ContainerName, cancellationToken);
		}
	}
}
