using Application.Dtos;
using Application.Entities;
using Application.Exceptions;
using Application.Helpers;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.ValueObjects;
using MediatR;

namespace Application.Commands.Files
{
	public class UploadFileCommnadHandler : IRequestHandler<UploadFileRequestDto, AppResponseDto>
	{
		private readonly IRepository<AppFile> _appFiles;
		private readonly IBlobStorage _blobStorage;

		public UploadFileCommnadHandler(IRepository<AppFile> appFiles, IBlobStorage blobStorage)
		{
			_appFiles = appFiles;
			_blobStorage = blobStorage;
		}


		private async Task<string[]> AddAppfilesAsync(Guid ownerId, string extentions)
		{
			string[] extentionList = extentions.Split(",");
			for (int i = 0; i < extentionList.Length; i++)
			{



				await _appFiles.DbSet.AddAsync(
					new AppFile(ownerId,)
			}
		}

		public async Task<AppResponseDto> Handle(UploadFileRequestDto request, CancellationToken cancellationToken)
		{
			if (!request.Streams.Any()) throw new StreamNotFoundException();
			foreach (var stream in request.Streams)
			{
				var appFileName = CreateUniqFileName.RunHelper(request.OwnerId, request.Extentions);
				var appFile = new AppFile(request.OwnerId, appFileName,new ContainerName(request.ContainerName));
				await _blobStorage.UploadAsync(stream, appFileName, request.ContainerName, cancellationToken);
				await _appFiles.DbSet.AddAsync(appFile);
			}
			return AppResponseDto.Success();
		}
	}
}
