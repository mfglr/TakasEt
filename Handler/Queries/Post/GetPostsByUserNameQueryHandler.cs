﻿using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Handler.Queries
{
	public class GetPostsByUserNameQueryHandler : IRequestHandler<GetPostsByUserName, AppResponseDto>
	{
		private readonly IRepository<Post> _posts;
		public GetPostsByUserNameQueryHandler(IRepository<Post> posts)
		{
			_posts = posts;
		}
		public async Task<AppResponseDto> Handle(GetPostsByUserName request, CancellationToken cancellationToken)
		{
			var posts = await _posts
				.DbSet
				.AsNoTracking()
				.Include(x => x.PostImages)
				.Include(x => x.UsersWhoLiked)
				.Include(x => x.UsersWhoViewed)
				.Include(x => x.Comments)
				.Include(x => x.User)
				.Include(x => x.Category)
				.Where(x => x.CreatedDate < request.getQueryDate() && x.User.UserName == request.UserName)
				.OrderByDescending(x => x.CreatedDate)
				.Skip(request.Skip)
				.Take(request.Take)
				.ToPostResponseDto()
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success(posts);
		}
	}
}
