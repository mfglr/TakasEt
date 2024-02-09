using PhotoStockMicroservice.Api.Services.Abstracts;
using SharedLibrary.Dtos;
using SharedLibrary.ValueObjects;
using System.Reflection;

namespace PhotoStockMicroservice.Api.Services.Concreate
{
	public class LocalBlobService : IBlobService
	{

		private readonly IImageService _imageService;

        public LocalBlobService(IImageService imageService)
        {
            _imageService = imageService;
        }

		private string getPath(string path)
		{
            Assembly asm = Assembly.GetExecutingAssembly();
            return $"{Path.GetDirectoryName(asm.Location)}/{path}";
        }

        private string getPath(string containerName,string blobName)
		{
			Assembly asm = Assembly.GetExecutingAssembly();
			return $"{Path.GetDirectoryName(asm.Location)}/{containerName}/{blobName}";
		}

		private string CreateUniqBlobName(string extention)
		{
			return $"{Guid.NewGuid()}_{DateTime.Now.Ticks}_{Guid.NewGuid()}.{extention}";
		}

        public void CreateContainer(string containerName)
        {
			var path = getPath(containerName);
			Directory.CreateDirectory(path);
        }

        public void Delete(string containerName, string blobName)
		{
			string path = getPath(containerName, blobName);
			if (!File.Exists(path)) throw new Exception("File is not found");
			File.Delete(path);
		}

		public async Task<byte[]> DownloadAsync(string containerName, string blobName,  CancellationToken cancellationToken)
		{
			string path = getPath(containerName,blobName);

			var stream = File.OpenRead(path);
			var bytes = new byte[stream.Length];
			await stream.ReadAsync(bytes,0,bytes.Length,cancellationToken);
			return bytes;
		}

		public async Task<ImageResponDto> UploadImageAsync(IFormFile file, string containerName,CancellationToken cancellationToken)
		{
			using var stream = file.OpenReadStream();
			if(stream == null || stream.Length == 0) throw new Exception("A stream is required");
			
			var extention = Path.GetExtension(file.Name) ?? throw new Exception("The extention of file undefined");

			var blobName = CreateUniqBlobName(extention);
			string path = getPath(containerName, blobName);

            Dimension dimension;
			using var fileStream = File.Create(path);
			await stream.CopyToAsync(fileStream, cancellationToken);
			dimension = _imageService.GetDimension(fileStream);

			return new ImageResponDto()
			{
				ContainerName = containerName,
				BlobName = blobName,
                Extention = extention,
                Height = dimension.Height,
				Width = dimension.Width,
				AspectRatio = dimension.AspectRatio,
			};

		}

        public async Task<List<ImageResponDto>> UploadImagesAsync(IFormFileCollection files, string containerName, CancellationToken cancellationToken)
        {
			if (files.Count == 0) throw new Exception("A file is required!");
			
			var fileResponses = new List<ImageResponDto>();
			try
			{
                foreach (var file in files)
                    fileResponses.Add(await UploadImageAsync(file, containerName, cancellationToken));
            }
			catch (Exception ex)
			{
                //if there is an error when uploading files, delete the uploaded files. All or none!
                foreach (var response in fileResponses)
					Delete(containerName, response.BlobName);
				throw new Exception("There have been some issues while uploading files. Upload failed!");
			}

            return fileResponses;
        }

        
    }	
}
