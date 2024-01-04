using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Exceptions;
using Application.Helpers;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.ValueObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Commands
{
    public class AddPostCommandHandler : IRequestHandler<AddPost, AppResponseDto>
    {
        private readonly IBlobService _blobService;
        private readonly IRepository<User> _users;
        private readonly LoggedInUser _loggedInUser;

        public AddPostCommandHandler(IBlobService blobService, LoggedInUser loggedInUser, IRepository<User> users)
        {
            _blobService = blobService;
            _loggedInUser = loggedInUser;
            _users = users;
        }

        public async Task<AppResponseDto> Handle(AddPost request, CancellationToken cancellationToken)
        {
            var user = await _users.DbSet.FirstOrDefaultAsync(x => x.Id == _loggedInUser.UserId, cancellationToken);

            if (user == null) throw new UserNotFoundException();

            var post = new Post(_loggedInUser.UserId, request.Title, request.Content, request.CategoryId, request.CountOfImages);

            var extentions = request.Extentions.Split(',');
            var list = extentions.Zip(request.Streams, (extention, stream) => new { extention, stream });
            int index = 0;
            foreach (var iter in list)
            {
                var fileName = CreateUniqFileName.RunHelper(iter.extention);
                await _blobService.UploadAsync(iter.stream, fileName, ContainerName.PostImage.Value, cancellationToken);
                post.AddImage(new PostImage(fileName, iter.extention, index));
                index++;
            }
            user.AddPost(post);

            return AppResponseDto.Success();
        }
    }
}
