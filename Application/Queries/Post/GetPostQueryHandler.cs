﻿using Application.Dtos;
using Application.Entities;
using Application.Exceptions;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries
{
    public class GetPostQueryHandler : IRequestHandler<GetPost, AppResponseDto>
    {
		private readonly IRepository<Post> _posts;
		private readonly IMapper _mapper;

		public GetPostQueryHandler(IRepository<Post> posts, IMapper mapper)
		{
			_posts = posts;
			_mapper = mapper;
		}

		public async Task<AppResponseDto> Handle(GetPost request, CancellationToken cancellationToken)
        {
			var post = await _posts
				.DbSet
				.Include(x => x.User)
				.Include(x => x.Category)
				.FirstOrDefaultAsync(post => post.Id == request.PostId, cancellationToken);
			if (post == null) throw new PostNotFoundException();
			return AppResponseDto.Success( _mapper.Map<PostResponseDto>(post) );
        }
    }
}