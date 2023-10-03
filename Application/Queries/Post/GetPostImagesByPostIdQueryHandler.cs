using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries
{
    public class GetPostImagesByPostIdQueryHandler : IRequestHandler<GetPostImagesByPostIdRequestDto, byte[]>
    {
        private readonly IBlobService _blobService;
        private readonly IRepository<PostImage> _appFiles;
        private readonly IFileWriterService _fileWriterService;

        public GetPostImagesByPostIdQueryHandler(IBlobService blobService, IRepository<PostImage> appFiles, IFileWriterService fileWriterService)
        {
            _blobService = blobService;
            _appFiles = appFiles;
            _fileWriterService = fileWriterService;
        }

        public async Task<byte[]> Handle(GetPostImagesByPostIdRequestDto request, CancellationToken cancellationToken)
        {
            var files = await _appFiles.DbSet.Where(x => x.PostId == request.PostId).ToListAsync();
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
