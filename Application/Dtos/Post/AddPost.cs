using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class AddPost : IRequest<AppResponseDto>
	{
		public int CategoryId { get; private set; }
		public string Title { get; private set; }
		public string Content { get; private set; }
		public string Extentions { get; private set; }
		public int CountOfImages { get; private set; }
		public IReadOnlyCollection<Stream> Streams => _streams;
        private readonly List<Stream> _streams = new List<Stream>();

        public AddPost(IFormCollection form)
        {
			foreach(var file in form.Files)
				_streams.Add(file.OpenReadStream());
			Extentions = form.Where(x => x.Key == "extentions").Select(x => x.Value).FirstOrDefault().ToString();
			CategoryId = int.Parse(form.Where(x => x.Key == "categoryId").Select(x => x.Value).FirstOrDefault().ToString());
			Title = form.Where(x => x.Key == "title").Select(x => x.Value).FirstOrDefault().ToString();
			Content = form.Where(x => x.Key == "content").Select(x => x.Value).FirstOrDefault().ToString();
			CountOfImages = int.Parse(
				form.Where(x => x.Key == "countOfImages").Select(x => x.Value).FirstOrDefault().ToString()
			);
		}
    }
}
