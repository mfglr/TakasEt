using Application.Dtos;
using Application.Entities;
using Application.Helpers;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.ValueObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Commands
{
    public class AddPostCommandHandler : IRequestHandler<AddPostDto, AppResponseDto>
    {
        private readonly IBlobService _blobService;
        private readonly IRepository<User> _users;
        private readonly IImageService _imageService;

		public AddPostCommandHandler(IBlobService blobService, IRepository<User> users, IImageService imageService)
		{
			_blobService = blobService;
			_users = users;
			_imageService = imageService;
		}

		public async Task<AppResponseDto> Handle(AddPostDto request, CancellationToken cancellationToken)
        {
            var user = await _users.DbSet.FirstOrDefaultAsync(x => x.Id == request.LoggedInUserId, cancellationToken);
            var post = new Post((int)request.LoggedInUserId!,request.Title!,request.Content!,(int)request.CategoryId!,(int)request.NumberOfImages!);

            var list = request.Extentions!.Zip(request.Streams!, (extention, stream) => new { extention, stream });
            int index = 0;
            foreach (var iter in list)
            {
                var fileName = CreateUniqFileName.RunHelper(iter.extention);
                var dimention = _imageService.GetDimension(iter.stream);
				await _blobService.UploadAsync(iter.stream, fileName, ContainerName.PostImage, cancellationToken);
                post.AddImage(fileName, iter.extention, index,dimention);
                index++;
            }
            user!.AddPost(post);
            return AppResponseDto.Success();
        }
    }
}
