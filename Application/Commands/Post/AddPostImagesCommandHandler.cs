using Application.Dtos;
using Application.Entities;
using Application.Exceptions;
using Application.Helpers;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.ValueObjects;
using MediatR;

namespace Application.Commands
{
	public class AddPostImagesCommandHandler : IRequestHandler<UploadFileRequestDto, AppResponseDto>
	{
		private readonly IBlobStorage _blobStorage;
		private readonly IRepository<AppFile> _appFiles;

		public AddPostImagesCommandHandler(IBlobStorage blobStorage, IRepository<AppFile> appFiles)
		{
			_blobStorage = blobStorage;
			_appFiles = appFiles;
		}

		public async Task<AppResponseDto> Handle(UploadFileRequestDto request, CancellationToken cancellationToken)
		{
			var appFileName = CreateUniqFileName.RunHelper(request.OwnerId, request.Extention);
			var appFile = new AppFile(appFileName, ContainerName.PostImage.Value);
			appFile.PostId = request.OwnerId;
			await _appFiles.DbSet.AddAsync(appFile);
			if (!request.Streams.Any()) throw new StreamNotFoundException();
			foreach (var stream in request.Streams)
				await _blobStorage.UploadAsync(stream, appFileName, ContainerName.PostImage.Value, cancellationToken);
			return AppResponseDto.Success();
		}
	}
}
