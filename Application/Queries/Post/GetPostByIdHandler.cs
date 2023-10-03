using Application.Dtos;
using Application.Entities;
using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries
{
    public class GetPostByIdHandler : IRequestHandler<GetPostByIdRequestDto, AppResponseDto>
    {
		private readonly IMapper _mapper;
		private readonly IRepository<Post> _posts;

		public GetPostByIdHandler(IMapper mapper, IRepository<Post> posts)
		{
			_mapper = mapper;
			_posts = posts;
		}

		public async Task<AppResponseDto> Handle(GetPostByIdRequestDto request, CancellationToken cancellationToken)
        {
			var post = await _posts
				.DbSet
				.Include(x => x.User)
				.Include(x => x.Category)
				.FirstOrDefaultAsync(post => post.Id == request.PostId);
			
			if (post == null) throw new PostNotFoundException();
			return AppResponseDto.Success(_mapper.Map<PostResponseDto>(post));
        }
    }
}
