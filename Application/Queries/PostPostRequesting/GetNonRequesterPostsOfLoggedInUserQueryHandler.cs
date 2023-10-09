using Application.Configurations;
using Application.Dtos;
using Application.Dtos.PostPostRequesting;
using Application.Entities;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries
{
	public class GetNonRequesterPostsOfLoggedInUserQueryHandler : IRequestHandler<GetNonRequesterPostsOfLoggedInUserRequestDto, AppResponseDto>
	{

		private readonly IRepository<PostPostRequesting> _requestings;
		private readonly LoggedInUser _loggedInUser;
		private readonly IMapper _mapper;

		public GetNonRequesterPostsOfLoggedInUserQueryHandler(IRepository<PostPostRequesting> requestings, LoggedInUser loggedInUser, IMapper mapper)
		{
			_requestings = requestings;
			_loggedInUser = loggedInUser;
			_mapper = mapper;
		}
		public async Task<AppResponseDto> Handle(GetNonRequesterPostsOfLoggedInUserRequestDto request, CancellationToken cancellationToken)
		{
			var posts = await _requestings
				.DbSet
				.Include(x => x.Requester)
				.ThenInclude(x => x.User)
				.Include(x => x.Requester)
				.ThenInclude(x => x.Category)
				.Where(
					x => x.RequestedId != request.PostId &&
					x.Requester.User.Id == _loggedInUser.UserId
				)
				.Select(x => x.Requester)
				.ToListAsync();
			return AppResponseDto.Success(_mapper.Map<List<PostResponseDto>>(posts));
		}
	}
}
