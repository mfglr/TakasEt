using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class GetUsersByFilter : IRequest<AppResponseDto>
	{
		public GetUsersByFilter(IQueryCollection collection)
		{
			//Id = Guid.Parse(collection.Where(x => x.Key == "id").FirstOrDefault().Value.ToString());
			Key = collection.Where(x => x.Key == "key").FirstOrDefault().Value.ToString();
			Gender = bool.Parse(collection.Where(x => x.Key == "gender").FirstOrDefault().Value.ToString());
			//MinDateOfBirth = DateTime.Parse(collection.Where(x => x.Key == "minDateOfBirth").FirstOrDefault().Value.ToString());
			//MaxDateOfBirth = DateTime.Parse(collection.Where(x => x.Key == "maxDateOfBirth").FirstOrDefault().Value.ToString());
		}

		
		public Guid? Id { get; set; }
        public string? Key { get; set; }
        public bool? Gender { get; set; }
        public DateTime? MinDateOfBirth { get; set; }
        public DateTime? MaxDateOfBirth { get; set; }
    }
}
