using Application.Dtos;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;

namespace Function.Functions
{
	public class AppFileFunctions
    {
        private readonly ISender _sender;

		public AppFileFunctions(ISender sender)
		{
			_sender = sender;
		}

		[Function("app-file/get-by-key/{containerName}/{blobName}")]
        public async Task<byte[]> GetByKey(
            [HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req,
            string containerName,
            string blobName
        )
        {
            return await _sender.Send(new GetAppFileByKeyRequestDto(blobName,containerName));
        }

	}
}
