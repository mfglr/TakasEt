using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries
{
    public class GetRequesterPostsQueryHandler : IRequestHandler<GetRequesterPostsRequestDto, AppResponseDto>
    {
        private readonly IRepository<PostPostRequesting> _swapRequests;
        private readonly IMapper _mapper;

        public GetRequesterPostsQueryHandler(IRepository<PostPostRequesting> swapRequests, IMapper mapper)
        {
            _swapRequests = swapRequests;
            _mapper = mapper;
        }

        public async Task<AppResponseDto> Handle(GetRequesterPostsRequestDto request, CancellationToken cancellationToken)
        {
            var posts = await _swapRequests
                .DbSet
                .Include(x => x.Requester)
                .ThenInclude(x => x.User)
                .Include(x => x.Requester)
                .ThenInclude(x => x.Category)
                .Where(x => x.RequestedId == request.PostId)
                .Select(x => x.Requester)
                .ToListAsync();
            return AppResponseDto.Success(_mapper.Map<List<PostResponseDto>>(posts));

        }
    }
}
