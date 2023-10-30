using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Handler.Queries
{
	//*Belirli bir postun resimlerini verir.
	//*Postu id si ile belirler.
	public class GetPostImagesQueryHandler : IRequestHandler<GetPostImages, byte[]>
    {
        private readonly IBlobService _blobService;
        private readonly IRepository<PostImage> _postImages;
        private readonly IFileWriterService _fileWriterService;

        public GetPostImagesQueryHandler(IBlobService blobService, IRepository<PostImage> postImages, IFileWriterService fileWriterService)
        {
            _blobService = blobService;
			_postImages = postImages;
            _fileWriterService = fileWriterService;
        }

        public async Task<byte[]> Handle(GetPostImages request, CancellationToken cancellationToken)
        {
            var files = await _postImages
				.DbSet
				.AsNoTracking()
				.Where(x => x.PostId == request.PostId)
                .ToPage(request)
                .ToListAsync();
            foreach (var file in files)
                await _fileWriterService.WriteFileAsync(
                    await _blobService.DownloadAsync(file.BlobName, file.ContainerName, cancellationToken),
                    file.Extention,
                    cancellationToken
                );
            return _fileWriterService.Bytes;
        }
    }
}
