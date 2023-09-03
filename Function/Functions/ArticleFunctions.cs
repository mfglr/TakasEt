using Application.Dtos;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Newtonsoft.Json;

namespace Function.Functions
{
    public class ArticleFunctions
    {
        private readonly ISender _sender;

        public ArticleFunctions(ISender sender)
        {
            _sender = sender;
        }

        [Function("add-article")]
        public async Task<AddArticleResponseDto> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
            string json;
            using (var reader = new StreamReader(req.Body))
                json = await reader.ReadToEndAsync();
            var article = JsonConvert.DeserializeObject<AddArticleRequestDto>(json);
            return await _sender.Send(article);
        }
    }
}
