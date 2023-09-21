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
		
		public async Task<AppResponseDto> Handle(UploadFileRequestDto request, CancellationToken cancellationToken)
		{
			if (!request.Streams.Any()) throw new StreamNotFoundException();
			var extentions = request.Extentions.Split(",");
			var iter = request.Streams.GetEnumerator();
			iter.MoveNext();
			for (int i = 0; i < extentions.Length;i++)
			{
				var appFileName = CreateUniqFileName.RunHelper(request.OwnerId, extentions[i]);
				var appFile = new AppFile(request.OwnerId, appFileName,new ContainerName(request.ContainerName));
				await _blobStorage.UploadAsync(iter.Current, appFileName, request.ContainerName, cancellationToken);
				await _appFiles.DbSet.AddAsync(appFile);
				iter.MoveNext();
			}
			return AppResponseDto.Success();
		}
	}
}
