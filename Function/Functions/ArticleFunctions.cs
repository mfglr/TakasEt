using Application.Dtos;
using Function.Extentions;
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
        public async Task<AppResponseDto<AddArticleResponseDto>> AddArticle([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
            return await _sender.Send( await req.ReadFromBodyAsync<AddArticleRequestDto>() );
        }

		[Function("remove-article")]
		public async Task<AppResponseDto<NoContentResponseDto>> RemoveArticle([HttpTrigger(AuthorizationLevel.Function, "delete")] HttpRequestData req)
		{
			return await _sender.Send( await req.ReadFromBodyAsync<RemoveArticleRequestDto>() );
		}

		[Function("get-article-by-id/{id}")]
		public async Task<AppResponseDto<ArticleResponseDto>> GetArticleById(
			[HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req,
			Guid id
			)
		{
			return await _sender.Send(new GetArticleByIdRequestDto(id));
		}
	}
}
