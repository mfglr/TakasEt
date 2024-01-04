using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Queries
{
	public class DenemeQueryHandler : IRequestHandler<Deneme, AppResponseDto>
	{

		private readonly IRepository<Post> _posts;

		public DenemeQueryHandler(IRepository<Post> posts)
		{
			_posts = posts;
		}

		public async Task<AppResponseDto> Handle(Deneme request, CancellationToken cancellationToken)
		{
			var data = await _posts.DbSet.FirstAsync(x => x.Id == 1,cancellationToken);
			data.Update("a");
			return AppResponseDto.Success();
		}
	}
}
