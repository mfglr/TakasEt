using Application.Dtos;
using Function.Extentions;
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

		[Function("file/upload")]
        public async Task<AppResponseDto> Upload([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
			var a = await MultipartFormDataParser.ParseAsync(req.Body);
			var dto = a.Parse();
			return await _sender.Send(dto);
        }

		[Function("file/download")]
		public async Task<AppResponseDto> Download([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req)
		{
			return await _sender.Send(await req.ReadFromBodyAsync<DownloadFileRequestDto>());
		}

	}
}
 