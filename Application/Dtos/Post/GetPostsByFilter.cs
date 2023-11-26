using Application.Extentions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetPostsByFilter : Pagination, IRequest<AppResponseDto>
	{
		public int? UserId { get; private set; }
		public int? CategoryId { get; private set; }
		public string? Key { get; private set; }
		public bool IncludeFolloweds { get; private set; }
		public bool IncludeLastSearchigns { get; private set; }

		public GetPostsByFilter(IQueryCollection collection) : base(collection)
		{
			string userId = collection.Where(x => x.Key == "userId").FirstOrDefault().Value.ToString();
			UserId = userId != "0" ? int.Parse(userId) : null;
			
			string categoryId = collection.Where(x => x.Key == "categoryId").FirstOrDefault().Value.ToString();
			CategoryId = categoryId != "0" ? int.Parse (categoryId) : null;
			
			string key = collection.Where(y => y.Key == "key").FirstOrDefault().Value.ToString();
			Key = key != "" ? key.CustomNormalize() : null;

			string includeFolloweds = collection.Where(y => y.Key == "includeFolloweds").FirstOrDefault().Value.ToString();
			IncludeFolloweds = bool.Parse(includeFolloweds);

			string includeLastSerchings = collection.Where(y => y.Key == "includeLastSearchings").FirstOrDefault().Value.ToString();
			IncludeLastSearchigns = bool.Parse(includeLastSerchings);
		}
	}
}
