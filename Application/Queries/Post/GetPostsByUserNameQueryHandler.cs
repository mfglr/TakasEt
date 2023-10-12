using Application.Dtos;
using Application.Dtos.Post;
using Application.Entities;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries
{
	public class GetPostsByUserNameQueryHandler : IRequestHandler<GetPostsByUserName, AppResponseDto>
	{
		private readonly IRepository<Post> _posts;
		private readonly IMapper _mapper;
		public GetPostsByUserNameQueryHandler(IRepository<Post> posts, IMapper mapper)
		{
			_posts = posts;
			_mapper = mapper;
		}
		public async Task<AppResponseDto> Handle(GetPostsByUserName request, CancellationToken cancellationToken)
		{
			var posts = await _posts
				.DbSet
				.Include(x => x.UsersWhoLiked)
				.Include(x => x.UsersWhoViewed)
				.Include(x => x.User)
				.Include(x => x.Category)
				.Where(post => post.User.UserName == request.UserName)
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success(_mapper.Map<List<PostResponseDto>>(posts));
		}
	}
}
