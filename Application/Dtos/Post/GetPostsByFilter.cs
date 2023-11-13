using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetPostsByFilter : Pagination, IRequest<AppResponseDto>
	{
		public Guid? UserId { get; private set; }
		public Guid? CategoryId { get; private set; }
		public string? Key { get; private set; }

		public GetPostsByFilter(IQueryCollection collection) : base(collection)
		{
			string userId = collection.Where(x => x.Key == "userId").FirstOrDefault().Value.ToString();
			UserId = userId != "" ? Guid.Parse(userId) : null;
			
			string categoryId = collection.Where(x => x.Key == "categoryId").FirstOrDefault().Value.ToString();
			CategoryId = categoryId != "" ? Guid.Parse (categoryId) : null;
			
			string key = collection.Where(y => y.Key == "key").FirstOrDefault().Value.ToString();
			Key = key != "" ? key : null;
		}
	}
}
