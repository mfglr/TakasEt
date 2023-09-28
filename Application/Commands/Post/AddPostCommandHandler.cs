using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using MediatR;

namespace Application.Commands
{
	public class AddPostCommandHandler : IRequestHandler<AddPostRequestDto, AppResponseDto>
	{
		private readonly IRepository<Post> _posts;
		private readonly IAppFileService _filService;
		
		public AddPostCommandHandler(IRepository<Post> posts, IAppFileService filService)
		{
			_posts = posts;
			_filService = filService;
		}

		public async Task<AppResponseDto> Handle(AddPostRequestDto request, CancellationToken cancellationToken)
		{
			var post = new Post(request.UserId,request.Title, request.Content, request.CategoryId);
			var result = await _posts.DbSet.AddAsync(post,cancellationToken);
			request.UploadFiles.setOwnerId(result.Entity.Id);
			await _filService.UploadAsync(request.UploadFiles, cancellationToken);
			return  AppResponseDto.Success();
		}
	}
}
