using Application.Dtos;
using Application.Entities;
using Application.Helpers;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.ValueObjects;
using Azure.Storage.Blobs;

namespace Service
{
	public class AppFileService : IAppFileService
	{

		private readonly BlobServiceClient _blobServiceClient;
		private readonly IRepository<AppFile> _appFiles;

		public AppFileService(BlobServiceClient blobServiceClient, IRepository<AppFile> appFiles)
		{
			_blobServiceClient = blobServiceClient;
			_appFiles = appFiles;
		}

		public async Task<byte[]> DownloadAsync(string name, string containerName, CancellationToken cancellationToken)
		{
			var blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
			return 
				(
					await blobContainerClient
					.GetBlobClient(name)
					.DownloadContentAsync(cancellationToken)
				)
				.Value
				.Content
				.ToArray();
		}

		public async Task UploadAsync(Stream stream, string blobName, string containerName,CancellationToken cancellationToken)
		{
			var blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
			await blobContainerClient.CreateIfNotExistsAsync();
			await blobContainerClient.SetAccessPolicyAsync(Azure.Storage.Blobs.Models.PublicAccessType.BlobContainer);
			await blobContainerClient.GetBlobClient(blobName).UploadAsync(stream, cancellationToken);
		}

		public async Task UploadAsync(UploadFilesRequestDto uploadFiles, CancellationToken cancellationToken)
		{
			var extentions = uploadFiles.Extentions.Split(',');
			var blobContainerClient = _blobServiceClient.GetBlobContainerClient(uploadFiles.ContainerName);
			var list = extentions.Zip(uploadFiles.Streams,(extention, stream) => new { extention, stream });
			foreach(var iter in list) {
				var fileName = CreateUniqFileName.RunHelper(uploadFiles.OwnerId, iter.extention);
				await _appFiles.DbSet.AddAsync(new AppFile(uploadFiles.OwnerId, fileName, new ContainerName(uploadFiles.ContainerName)));
				await blobContainerClient.GetBlobClient(fileName).UploadAsync(iter.stream, cancellationToken);
			}
		}
	}
}
