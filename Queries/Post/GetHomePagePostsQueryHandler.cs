﻿using Models.Extentions;
using Models.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Models.Dtos;
using Models.Entities;

namespace Queries
{
	public class GetHomePagePostsQueryHandler : IRequestHandler<GetHomePagePostsDto, AppResponseDto>
	{
		private readonly IRepository<Post> _posts;

		public GetHomePagePostsQueryHandler(IRepository<Post> posts)
		{
			_posts = posts;
		}

		public async Task<AppResponseDto> Handle(GetHomePagePostsDto request, CancellationToken cancellationToken)
		{
			var posts = await _posts
				.DbSet
				.AsNoTracking()
				.IncludePost()
				.Include(x => x.User)
				.ThenInclude(x => x.Followers)
				.Where( x => x.User.Followers.Any(x => x.FollowerId == request.LoggedInUserId) )
				.ToPage(request)
				.ToPostResponseDto(request.LoggedInUserId)
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success(posts);
		}
	}
}
