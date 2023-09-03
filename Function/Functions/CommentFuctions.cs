using Application.Dtos;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Newtonsoft.Json;

namespace Function.Functions
{
    public class CommentFuctions
    {
        private readonly IMediator _mediator;

        public CommentFuctions(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Function("add-comment")]
        public async Task<AddCommentResponseDto> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
            string json;
            using (var reader = new StreamReader(req.Body))
                json = await reader.ReadToEndAsync();
            var comment = JsonConvert.DeserializeObject<AddCommentRequestDto>(json, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return await _mediator.Send(comment);

        }
    }
}
