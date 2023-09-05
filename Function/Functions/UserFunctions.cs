using Application.Dtos;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Newtonsoft.Json;

namespace Function.Functions
{
	public class UserFunctions
	{
		private readonly ISender _sender;

		public UserFunctions(ISender sender)
		{
			_sender = sender;
		}

		[Function("remove-article")]
		public async Task<NoContentResponseDto> RemoveUser([HttpTrigger(AuthorizationLevel.Function, "delete")] HttpRequestData req)
		{
			string json;
			using (var reader = new StreamReader(req.Body))
				json = await reader.ReadToEndAsync();
			var article = JsonConvert.DeserializeObject<RemoveArticleRequestDto>(json);
			return await _sender.Send(article);
		}
	}
}
