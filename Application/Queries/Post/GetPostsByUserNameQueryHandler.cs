﻿using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries
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
				.Include(x => x.UsersWhoLiked)
				.Include(x => x.UsersWhoViewed)
				.Include(x => x.Comments)
				.Include(x => x.User)
				.Include(x => x.Category)
				.Where(post => post.User.UserName == request.UserName)
				.Select(x => new PostResponseDto()
				{
					Id = x.Id,
					CreatedDate = x.CreatedDate,
					UpdatedDate = x.UpdatedDate,
					UserId = x.User.Id,
					UserName = x.User.UserName,
					CategoryName = x.Category.Name,
					Title = x.Title,
					Content = x.Content,
					PublishedDate = x.PublishedDate,
					CountOfImages = x.CountOfImages,
					CountOfLikes = x.UsersWhoLiked.Count,
					CountOfViews = x.UsersWhoViewed.Count,
					CountOfComments = x.Comments.Count,
				})
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success(posts);
		}
	}
}
