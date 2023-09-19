﻿using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries
{
	public class GetFollowedsByUserIdQueryHandler : IRequestHandler<GetFollowedsByUserIdRequestDto, AppResponseDto>
	{
		private readonly IRepository<Following> _followings;
		public GetFollowedsByUserIdQueryHandler(IRepository<Following> followings)
		{
			_followings = followings;
		}

		public async Task<AppResponseDto> Handle(GetFollowedsByUserIdRequestDto request, CancellationToken cancellationToken)
		{
			var users = await _followings
				.DbSet
				.Include(x => x.Followed)
				.Where(x => x.FollowerId == request.FollowerId)
				.Include(x => x.Followed)
				.ThenInclude(x => x.Followeds)
				.Include(x => x.Followed)
				.ThenInclude(x => x.Followers)
				.Select(x => new UserResponseDto()
				{
					Id = x.Id,
					CreatedDate = x.CreatedDate,
					UpdatedDate = x.UpdatedDate,
					Name = x.Followed.Name,
					LastName = x.Followed.LastName,
					Email = x.Followed.Email!,
					UserName = x.Followed.UserName!,
					CountOfFolloweds = x.Followed.Followeds.Count(),
					CountOfFollowers = x.Followed.Followers.Count()
				})
				.ToListAsync();
			return AppResponseDto.Success(users);
		}
	}
}