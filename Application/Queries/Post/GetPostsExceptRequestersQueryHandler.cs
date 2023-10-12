using Application.Configurations;
using Application.Dtos;
using Application.Dtos.Post;
using Application.Entities;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries
{
    //*Belirli bir posta !!!herhangi bir post degil!!!, giris yapmis kullanicinin postlari
    // arasindaki, requester olmayan postlari verir.
    //*Post u id si ile belirler.

    public class GetPostsExceptRequestersQueryHandler : IRequestHandler<GetPostsExceptRequesters, AppResponseDto>
    {
        private readonly IRepository<Post> _posts;
        private readonly LoggedInUser _loggedInUser;
        private readonly IMapper _mapper;

        public GetPostsExceptRequestersQueryHandler(IRepository<PostPostRequesting> requestings, LoggedInUser loggedInUser, IMapper mapper, IRepository<Post> posts)
        {
            _loggedInUser = loggedInUser;
            _mapper = mapper;
            _posts = posts;
        }
        public async Task<AppResponseDto> Handle(GetPostsExceptRequesters request, CancellationToken cancellationToken)
        {
            var posts = await _posts
                .DbSet
                .Include(x => x.Requesteds)
                .Where(
                    x =>
                        x.UserId == _loggedInUser.UserId &&
                        !x.Requesteds.Select(r => r.RequestedId).Contains(request.PostId)
                )
                .ToListAsync(cancellationToken);
            return AppResponseDto.Success(_mapper.Map<List<PostResponseDto>>(posts));
        }
    }
}
