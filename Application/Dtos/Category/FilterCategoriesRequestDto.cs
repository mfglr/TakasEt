using MediatR;

namespace Application.Dtos
{
	public class FilterCategoriesRequestDto : IRequest<AppResponseDto>
	{
        public string Key { get; private set; }

		public FilterCategoriesRequestDto(string key)
		{
			Key = key;
		}
	}
}
