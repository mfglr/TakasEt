using Models.Extentions;
using Models.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Models.Dtos;
using Models.Entities;

namespace Queries
{
    public class GetUserQueryHandler : IRequestHandler<GetUserDto,AppResponseDto>
	{
		private readonly IRepository<User> _users;

		public GetUserQueryHandler(IRepository<User> users)
		{
			_users = users;
		}

		public async Task<AppResponseDto> Handle(GetUserDto request, CancellationToken cancellationToken)
		{
			
			var user = await _users
				.DbSet
				.AsNoTracking()
				.IncludeUser()
				.ToUserResponseDto(request.LoggedInUserId)
				.FirstOrDefaultAsync(x => x.Id == request.LoggedInUserId,cancellationToken);
			return AppResponseDto.Success(user);
		}
	}
}
