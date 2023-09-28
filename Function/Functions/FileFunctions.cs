using Application.Dtos;
using Function.Attributes;
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

		[Authorize("user")]
		[Function("file/upload")]
        public async Task<AppResponseDto> Upload([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
			return await _sender.Send(
				new UploadFilesRequestDto(
					await MultipartFormDataParser.ParseAsync(req.Body)
				)
			);
        }

		[Authorize("user")]
		[Function("file/download")]
		public async Task<AppResponseDto> Download([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req)
		{
			return await _sender.Send(await req.ReadFromBodyAsync<DownloadFileRequestDto>());
		}

	}
}
 