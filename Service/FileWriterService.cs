using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace Service
{
	public class FileWriterService : IFileWriterService
	{

		private static JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings()
		{
			ContractResolver = new CamelCasePropertyNamesContractResolver(),
			NullValueHandling = NullValueHandling.Ignore
		};

		private readonly IBlobService _blobService;
		private MemoryStream _writer;
		
		public byte[] Bytes => _writer.ToArray();
		
		private static int sizeOfInt = sizeof(int);

		private static byte[] systemInformations = new [] { 
			(byte)sizeOfInt,
			(byte)(!BitConverter.IsLittleEndian ? 1 : 0)
		};

		public FileWriterService(IBlobService blobService)
		{
			_writer = new MemoryStream();
			_writer.Write(systemInformations);
			_blobService = blobService;
		}

		public async Task WriteFileAsync(byte[] file,string extention,CancellationToken cancellationToken)
		{
			var lengthOfFile = BitConverter.GetBytes(file.Length);
			var bytesOfExtention = Encoding.UTF8.GetBytes(extention);
			var lengthOfExtention = BitConverter.GetBytes(bytesOfExtention.Length);

			await _writer.WriteAsync(lengthOfExtention,cancellationToken);
			await _writer.WriteAsync(bytesOfExtention,cancellationToken);
			await _writer.WriteAsync(lengthOfFile, cancellationToken);
			await _writer.WriteAsync(file, cancellationToken);
		}
		public async Task WriteFileAsync(FileResponseDto files,CancellationToken cancellationToken)
		{
			var jsonBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(files, _jsonSerializerSettings));
			await _writer.WriteAsync(BitConverter.GetBytes(jsonBytes.Length), cancellationToken);
			await _writer.WriteAsync(jsonBytes, cancellationToken);
			foreach (var file in files.AppFiles)
			{
				var fileBytes = await _blobService.DownloadAsync(file.BlobName, file.ContainerName, cancellationToken);
				await WriteFileAsync(fileBytes, file.Extention, cancellationToken);
			}
		}
		//private async Task WritePostAsync(PostResponseDto post,CancellationToken cancellationToken)
		//{
		//	var postBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(post,_jsonSerializerSettings));
		//	await _writer.WriteAsync(BitConverter.GetBytes(postBytes.Length), cancellationToken);
		//	await _writer.WriteAsync(postBytes, cancellationToken);
		//	var firstImage = post.AppFiles.OrderBy(x => x.Id).First();
		//	var bytesOfFirtsImage = await _blobService.DownloadAsync(firstImage.BlobName, firstImage.ContainerName, cancellationToken);
		//	await WriteFileAsync(bytesOfFirtsImage,firstImage.Extention, cancellationToken);
		//}

		private async Task WriteCommentAsync(CommentResponseDto comment,CancellationToken cancellationToken)
		{
			var commentBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(comment, _jsonSerializerSettings));
			await _writer.WriteAsync(BitConverter.GetBytes(commentBytes.Length), cancellationToken);
			await _writer.WriteAsync(commentBytes, cancellationToken);
			var bytesOfProfileImage = await _blobService.DownloadAsync(comment.ProfileImage.BlobName, comment.ProfileImage.ContainerName, cancellationToken);
			await WriteFileAsync(bytesOfProfileImage, comment.ProfileImage.Extention, cancellationToken);
		}

		//public async Task WriteFileResponsesAsync(List<FileResponseDto> files,CancellationToken cancellationToken)
		//{
		//	var postBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(post, _jsonSerializerSettings));
		//	await _writer.WriteAsync(BitConverter.GetBytes(postBytes.Length), cancellationToken);
		//	await _writer.WriteAsync(postBytes, cancellationToken);
		//	var firstImage = post.AppFiles.OrderBy(x => x.Id).First();
		//	var bytesOfFirtsImage = await _blobService.DownloadAsync(firstImage.BlobName, firstImage.ContainerName, cancellationToken);
		//	await WriteFileAsync(bytesOfFirtsImage, firstImage.Extention, cancellationToken);
		//}


		//public async Task WritePostListAsync(List<PostResponseDto> posts,CancellationToken cancellationToken)
		//{
		//	foreach (var post in posts) await WritePostAsync(post,cancellationToken);
		//}

		public async Task WriteCommentsAsync(List<CommentResponseDto> comments,CancellationToken cancellationToken)
		{
			foreach(var comment in comments) await WriteCommentAsync(comment,cancellationToken);
		}

	}

	
}
