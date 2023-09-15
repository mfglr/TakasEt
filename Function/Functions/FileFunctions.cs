using Application.Dtos;
using Function.Extentions;
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

		[Function("Upload")]
        public async Task<AppResponseDto<FileResponseDto>> Upload([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
            var data = await _sender.Send(await req.ReadFromBodyAsync<UploadFileDto>());
            return data;
        }
    }
}
