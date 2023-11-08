using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Handler.Queries
{
	public class GetFirstImagesOfPostsByUserNameQueryHandler : IRequestHandler<GetFirstImagesOfPostsByUserName, byte[]>
	{
		private readonly IRepository<PostImage> _postImages;
		private readonly IFileWriterService _fileWriter;
		private readonly IBlobService _blobService;

		public GetFirstImagesOfPostsByUserNameQueryHandler(IRepository<PostImage> postImages, IFileWriterService fileWriter, IBlobService blobService)
		{
			_postImages = postImages;
			_fileWriter = fileWriter;
			_blobService = blobService;
		}

		public async Task<byte[]> Handle(GetFirstImagesOfPostsByUserName request, CancellationToken cancellationToken)
		{
			var images = await _postImages
				.DbSet
				.AsNoTracking()
				.Include(x => x.Post)
				.ThenInclude(x => x.User)
				.Where(x => x.Post.User.UserName == request.UserName)
				.ToPage(x => x.Id, request)
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
