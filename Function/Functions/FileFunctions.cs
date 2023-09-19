using Application.Dtos;
using HttpMultipartParser;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace Function.Functions
{
    public class FileFunctions
    {
        private readonly ISender _sender;

		public FileFunctions(ISender sender)
		{
			_sender = sender;
		}

		private UploadFileDto parse(MultipartFormDataParser parser)
		{
			return new UploadFileDto(
				parser.Files.Select(x => x.Data),
				parser.Parameters.Where(x => x.Name.ToLower() == "containername").Select(x => x.Data).FirstOrDefault()
			);
		}


		[Function("Upload")]
        public async Task<AppResponseDto> Upload([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
			var request = parse(await MultipartFormDataParser.ParseAsync(req.Body));
			return await _sender.Send(request);
        }
    }
}
 