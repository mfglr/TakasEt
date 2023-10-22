using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries
{
	//*Belir bir kullanicinin postlarinin ilk resimlerini verir.
	//*Kullaniciyi id si ile belirler.
	public class GetFirstImagesOfPostsByUserIdQueryHandler : IRequestHandler<GetFirstImagesOfPostsByUserId, byte[]>
    {
        private readonly IRepository<PostImage> _postImages;
        private readonly IFileWriterService _fileWriter;
        private readonly IBlobService _blobService;

        public GetFirstImagesOfPostsByUserIdQueryHandler(IRepository<PostImage> postImages, IFileWriterService fileWriter, IBlobService blobService)
        {
            _postImages = postImages;
            _fileWriter = fileWriter;
            _blobService = blobService;
        }

        public async Task<byte[]> Handle(GetFirstImagesOfPostsByUserId request, CancellationToken cancellationToken)
        {
            var images = await _postImages
                .DbSet
				.AsNoTracking()
				.Include(x => x.Post)
                .ThenInclude(x => x.User)
                .Where(x => x.Post.User.Id == request.UserId)
                .ToPage(request)
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
