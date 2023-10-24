using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Handler.Queries
{
	public class GetFirsImagesOfPostsExceptReuqestersQueryHandler : IRequestHandler<GetFirstImagesOfPostsExceptRequesters, byte[]>
	{
		private readonly IRepository<PostImage> _postImages;
		private readonly IBlobService _blobServices;
		private readonly LoggedInUser _loggedInUser;
		private readonly IFileWriterService _writerService;

		public GetFirsImagesOfPostsExceptReuqestersQueryHandler(IRepository<PostImage> postImages, IBlobService blobServices, LoggedInUser loggedInUser, IFileWriterService writerService)
		{
			_postImages = postImages;
			_blobServices = blobServices;
			_loggedInUser = loggedInUser;
			_writerService = writerService;
		}

		public async Task<byte[]> Handle(GetFirstImagesOfPostsExceptRequesters request, CancellationToken cancellationToken)
		{
			var images = await _postImages
				.DbSet
				.AsNoTracking()
				.Include(x => x.Post)
				.ThenInclude(x => x.User)
				.Include(x => x.Post)
				.ThenInclude(x => x.Requesteds)
				.Where(
					x =>
						x.Post.User.Id == _loggedInUser.UserId &&
						!x.Post.Requesteds.Select(r => r.RequestedId).Contains(request.PostId)
				)
				.GroupBy(x => x.Post)
				.Select(x => x.OrderBy(image => image.Id).First())
				.ToPage(request)
				.ToListAsync(cancellationToken);
			
			foreach (var image in images) {
				var bytes = await _blobServices.DownloadAsync(image.BlobName, image.ContainerName, cancellationToken);
				await _writerService.WriteFileAsync(bytes, image.Extention, cancellationToken);
			}
			return _writerService.Bytes;
		}
	}
}
