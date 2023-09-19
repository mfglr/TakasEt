using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Commands
{
	public class AddPostCommandHandler : IRequestHandler<AddPostRequestDto, AppResponseDto>
	{
		private readonly IMapper _mapper;
		private readonly IRepository<Post> _posts;

		public AddPostCommandHandler(IMapper mapper, IRepository<Post> posts)
		{
			_mapper = mapper;
			_posts = posts;
		}

		public async Task<AppResponseDto> Handle(AddPostRequestDto request, CancellationToken cancellationToken)
		{
			var post = new Post(request.UserId,request.Title, request.Content, request.CategoryId);
			await _posts.DbSet.AddAsync(post,cancellationToken);
			return  AppResponseDto.Success(_mapper.Map<AddPostResponseDto>(post));
		}
	}
}
