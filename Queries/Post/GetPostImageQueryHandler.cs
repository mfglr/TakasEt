using Models.Interfaces.Repositories;
using Models.Interfaces.Services;
using MediatR;
using Models.Dtos;
using Models.Entities;

namespace Queries
{
	public class GetPostImageQueryHandler : IRequestHandler<GetPostImageDto, byte[]>
	{
		private readonly IBlobService _blobService;
		private readonly IRepository<PostImage> _postImages;

		public GetPostImageQueryHandler(IBlobService blobService, IRepository<PostImage> postImages)
		{
			_blobService = blobService;
			_postImages = postImages;
		}

		public async Task<byte[]> Handle(GetPostImageDto request, CancellationToken cancellationToken)
		{
			var postImage = await _postImages.DbSet.FindAsync(request.Id);
			return await _blobService.DownloadAsync(postImage!.BlobName, postImage.ContainerName, cancellationToken);
		}
	}
}
