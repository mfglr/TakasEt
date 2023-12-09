using Application.Extentions;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetExplorePagePosts : Pagination, IRequest<AppResponseDto>
	{
        public IEnumerable<string>? Tags { get; set; }
		public int? CategoryId { get; set; }

        public GetExplorePagePosts(IQueryCollection collection) : base(collection)
		{

			var tags = collection.Where(x => x.Key == "tags").FirstOrDefault().Value.ToString();
			if(tags == "") Tags = null;
			else Tags = tags.Split(',').Select(x => x.CustomNormalize());
			
			var categoryId = collection.Where(x => x.Key == "categoryId").FirstOrDefault().Value.ToString();
			if (categoryId == "") categoryId = null;
			else CategoryId = int.Parse(categoryId);

		}
	}
}
