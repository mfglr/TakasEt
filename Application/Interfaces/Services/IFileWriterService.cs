using Application.Dtos;

namespace Application.Interfaces.Services
{
	public interface IFileWriterService
	{
		Task WriteFileAsync(byte[] file, string extention, CancellationToken cancellationToken);
		//Task WritePostListAsync(List<PostResponseDto> posts, CancellationToken cancellationToken);
		Task WriteCommentsAsync(List<CommentResponseDto> comments, CancellationToken cancellationToken);
		byte[] Bytes { get; }
	}

}
