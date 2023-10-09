using Application.Dtos;
using Application.Entities;
using Application.Helpers;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.ValueObjects;
using MediatR;

namespace Application.Commands
{
	public class AddPostCommandHandler : IRequestHandler<AddPostRequestDto, AppResponseDto>
	{
		private readonly IBlobService _blobService;
		private readonly IRepository<Post> _posts;
		private readonly IRepository<AppFile> _appFiles;

		public AddPostCommandHandler(IRepository<Post> posts, IBlobService blobService, IRepository<AppFile> appFiles)
		{
			_posts = posts;
			_blobService = blobService;
			_appFiles = appFiles;
		}

		public async Task<AppResponseDto> Handle(AddPostRequestDto request, CancellationToken cancellationToken)
		{
			var post = new Post(request.UserId,request.Title, request.Content, request.CategoryId,request.CountOfImages);
			var result = await _posts.DbSet.AddAsync(post,cancellationToken);
			var extentions = request.Extentions.Split(',');
			var list = extentions.Zip(request.Streams, (extention, stream) => new { extention, stream });
			foreach (var iter in list)
			{
				var fileName = CreateUniqFileName.RunHelper(result.Entity.Id,iter.extention);
				await _appFiles.DbSet.AddAsync(new PostImage(result.Entity.Id,fileName,iter.extention));
				await _blobService.UploadAsync(iter.stream,fileName,ContainerName.PostImage.Value, cancellationToken);
			}
			return  AppResponseDto.Success();
		}
	}
}
