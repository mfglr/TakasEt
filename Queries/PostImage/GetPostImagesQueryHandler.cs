using Application.Dtos;
using Application.Entities;
using Application.Extentions;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Queries
{
	public class GetPostImagesQueryHandler : IRequestHandler<GetPostImagesDto, AppResponseDto>
	{
		private readonly IRepository<PostImage> _postImages;
		private readonly IMapper _mapper;

		public GetPostImagesQueryHandler(IRepository<PostImage> postImages, IMapper mapper)
		{
			_postImages = postImages;
			_mapper = mapper;
		}

		public async Task<AppResponseDto> Handle(GetPostImagesDto request, CancellationToken cancellationToken)
		{
			var images = await _postImages
				.DbSet
				.AsNoTracking()
				.Where(x => x.PostId == request.PostId)
				.ToPage(request)
				.ToListAsync(cancellationToken);
			return AppResponseDto.Success(_mapper.Map<PostImageResponseDto>(images));
		}
	}
}
