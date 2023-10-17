using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries
{
	public class GetFirstImagesOfPostsQueryHandler : IRequestHandler<GetFirstImagesOfPosts, byte[]>
	{
		private readonly IRepository<PostImage> _postImages;
		private readonly IFileWriterService _fileWriter;
		private readonly IBlobService _blobService;

		public GetFirstImagesOfPostsQueryHandler(IRepository<PostImage> postImages, IFileWriterService fileWriter, IBlobService blobService)
		{
			_postImages = postImages;
			_fileWriter = fileWriter;
			_blobService = blobService;
		}

		public async Task<byte[]> Handle(GetFirstImagesOfPosts request, CancellationToken cancellationToken)
		{
			var images = await _postImages
				.DbSet
				.AsNoTracking()
				.GroupBy(x => x.Post)
				.Select(x => x.OrderBy(x => x.Id).First())
				.ToListAsync(cancellationToken);
			
			foreach (var image in images)
			{
				var file = await _blobService.DownloadAsync(image.BlobName, image.ContainerName, cancellationToken);
				await _fileWriter.WriteFileAsync(file, image.Extention, cancellationToken);
			}
			return _fileWriter.Bytes;
		}
	}
}
