using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Handler.Queries
{
	public class GetPostImagesQueryHandler : IRequestHandler<GetPostImages, AppResponseDto>
	{
		private readonly IRepository<PostImage> _postImages;
		private readonly IMapper _mapper;

		public GetPostImagesQueryHandler(IRepository<PostImage> postImages, IMapper mapper)
		{
			_postImages = postImages;
			_mapper = mapper;
		}

		public async Task<AppResponseDto> Handle(GetPostImages request, CancellationToken cancellationToken)
		{
			var images = await _postImages
				.DbSet
				.AsNoTracking()
				.Where(x => x.PostId == request.PostId)
				.OrderBy(x => x.Id)
				.Skip(request.Skip)
				.Take(request.Take)
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success(_mapper.Map<PostImageResponseDto>(images));
		}
	}
}
