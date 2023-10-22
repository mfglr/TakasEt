using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class FilterCategories : Pagination,IRequest<AppResponseDto>
	{
        public string Key { get; private set; }

		public FilterCategories(string key,IQueryCollection collection) : base(collection)
		{
			Key = key;
		}
	}
}
