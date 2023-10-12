using MediatR;

namespace Application.Dtos
{
	public class FilterCategories : IRequest<AppResponseDto>
	{
        public string Key { get; private set; }

		public FilterCategories(string key)
		{
			Key = key;
		}
	}
}
