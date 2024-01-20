using Application.Extentions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class AddPostDto : IRequest<AppResponseDto>
	{
		public string? Title { get; private set; }
		public string? Content { get; private set; }
		public int? CategoryId { get; private set; }
		public int? NumberOfImages { get; private set; }
        public int? LoggedInUserId { get; private set; }
		public IReadOnlyCollection<string>? Extentions { get; private set; }
		public IReadOnlyCollection<Stream>? Streams { get; private set; }

        public AddPostDto(IFormCollection form)
        {
			Extentions = form.ReadStringList("extentions");
			CategoryId = form.ReadInt("categoryId");
			Title = form.ReadString("title");
			Content = form.ReadString("content");
			NumberOfImages = form.ReadInt("numberOfImages");
			Streams = form.ReadStreams();
		}
    }
}
