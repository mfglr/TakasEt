using Application.Dtos;
using Application.Entities;
using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Handler.Queries
{
	public class GetAppFileQueryHandler : IRequestHandler<GetAppFile, Stream>
	{
		private readonly IBlobService _blobService;
		private readonly IRepository<AppFile> _appFiles;

		public GetAppFileQueryHandler(IBlobService blobService, IRepository<AppFile> appFiles)
		{
			_blobService = blobService;
			_appFiles = appFiles;
		}

		public async Task<Stream> Handle(GetAppFile request, CancellationToken cancellationToken)
		{
			var appFile = await _appFiles
				.DbSet
				.AsNoTracking()
				.FirstOrDefaultAsync(appFile => appFile.Id == request.Id,cancellationToken);
			if (appFile == null) throw new AppFileNotFoundException();
			return await _blobService.DownloadAsync(appFile.BlobName, appFile.ContainerName, cancellationToken);
		}
	}
}
