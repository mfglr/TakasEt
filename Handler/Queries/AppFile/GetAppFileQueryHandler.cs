using Application.Dtos;
using Application.Entities;
using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Handler.Queries
{
	public class GetAppFileQueryHandler : IRequestHandler<GetAppFile, byte[]>
	{
		private readonly IBlobService _blobService;
		private readonly IRepository<AppFile> _appFiles;
		private readonly IFileWriterService _writerService;
		public GetAppFileQueryHandler(IBlobService blobService, IRepository<AppFile> appFiles, IFileWriterService writerService)
		{
			_blobService = blobService;
			_appFiles = appFiles;
			_writerService = writerService;
		}

		public async Task<byte[]> Handle(GetAppFile request, CancellationToken cancellationToken)
		{
			var appFile = await _appFiles
				.DbSet
				.AsNoTracking()
				.FirstOrDefaultAsync(appFile => appFile.Id == request.Id,cancellationToken);
			if (appFile == null) throw new AppFileNotFoundException();
			var data = await _blobService.DownloadAsync(appFile.BlobName, appFile.ContainerName, cancellationToken);
			await _writerService.WriteFileAsync(data, appFile.Extention, cancellationToken);
			return _writerService.Bytes;
		}
	}
}
