using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Helpers;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.ValueObjects;
using MediatR;

namespace Handler.Commands
{
	public class AddPostCommandHandler : IRequestHandler<AddPost, AppResponseDto>
	{
		private readonly IBlobService _blobService;
		private readonly IRepository<Post> _posts;
		private readonly LoggedInUser _loggedInUser;
		public AddPostCommandHandler(IRepository<Post> posts, IBlobService blobService, LoggedInUser loggedInUser)
		{
			_posts = posts;
			_blobService = blobService;
			_loggedInUser = loggedInUser;
		}

		public async Task<AppResponseDto> Handle(AddPost request, CancellationToken cancellationToken)
		{
			var post = new Post(_loggedInUser.UserId,request.Title, request.Content, request.CategoryId,request.CountOfImages);
			var result = await _posts.DbSet.AddAsync(post,cancellationToken);
			var extentions = request.Extentions.Split(',');
			var list = extentions.Zip(request.Streams, (extention, stream) => new { extention, stream });
			int index = 0;
			foreach (var iter in list)
			{
				var fileName = CreateUniqFileName.RunHelper(result.Entity.Id,iter.extention);
				post.AddImage(new PostImage(result.Entity.Id,fileName,iter.extention,index));
				await _blobService.UploadAsync(iter.stream,fileName,ContainerName.PostImage.Value, cancellationToken);
				index++;
			}
			return AppResponseDto.Success();
		}
	}
}
