﻿using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Queries
{
	public class GetPostsByKeyQueryHandler : IRequestHandler<GetPostsByKeyDto, AppResponseDto>
	{

		private readonly IRepository<Post> _posts;

		public GetPostsByKeyQueryHandler(IRepository<Post> posts)
		{
			_posts = posts;
		}

		public async Task<AppResponseDto> Handle(GetPostsByKeyDto request, CancellationToken cancellationToken)
		{

			var normalizeKey = request.Key.CustomNormalize();
			var posts = await _posts
				.DbSet
				.AsNoTracking()
				.IncludePost()
				.Where(
					post => (
						normalizeKey == null ||
						normalizeKey == "" ||
						post.NormalizedTitle.Contains(normalizeKey) ||
						post.Tags.Any(postTag => postTag.Tag.NormalizeName.Contains(normalizeKey))
					)
				)
				.ToPage(request)
				.ToPostResponseDto(request.LoggedInUserId)
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success(posts);

		}
	}
}
