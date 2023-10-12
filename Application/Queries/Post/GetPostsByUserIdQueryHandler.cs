using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries
{
	public class GetPostsByUserIdQueryHandler : IRequestHandler<GetPostsByUserId, AppResponseDto>
	{
		private readonly IRepository<Post> _posts;
		private readonly IMapper _mapper;
		public GetPostsByUserIdQueryHandler(IRepository<Post> posts, IMapper mapper)
		{
			_posts = posts;
			_mapper = mapper;
		}

		public async Task<AppResponseDto> Handle(GetPostsByUserId request, CancellationToken cancellationToken)
		{
			var posts = await _posts
				.DbSet
				.Include(x => x.UsersWhoLiked)
				.Include(x => x.UsersWhoViewed)
				.Include(x => x.User)
				.Include(x => x.Category)
				.Where(post => post.UserId == request.UserId)
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success(_mapper.Map<List<PostResponseDto>>(posts));
		}
	}
}
