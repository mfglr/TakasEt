using Application.Dtos;
using Application.Entities;
using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries
{
	public class GetAppFileByKeyQueryHandler : IRequestHandler<GetAppFileByKeyRequestDto, byte[]>
	{
		private readonly IBlobService _blobService;
		private readonly IRepository<AppFile> _appFiles;

		public GetAppFileByKeyQueryHandler(IBlobService blobService, IRepository<AppFile> appFiles)
		{
			_blobService = blobService;
			_appFiles = appFiles;
		}

		public async Task<byte[]> Handle(GetAppFileByKeyRequestDto request, CancellationToken cancellationToken)
		{
			if (
				!await _appFiles.DbSet.AnyAsync(
					appFile =>
						appFile.BlobName == request.BlobName &&
						appFile.ContainerName == request.ContainerName,
					cancellationToken
				)
			) throw new AppFileNotFoundException();
			return await _blobService.DownloadAsync(request.BlobName, request.ContainerName, cancellationToken);
		}
	}
}
