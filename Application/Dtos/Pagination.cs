using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class Pagination
	{
        public int Skip { get; set; }
        public int Take { get; set; }
        public long FirstQueryDate { get; set; }

        public Pagination(IQueryCollection collection)
        {
            Skip = int.Parse(collection.Where(x => x.Key == "skip").FirstOrDefault().Value.ToString());
			Take = int.Parse(collection.Where(x => x.Key == "take").FirstOrDefault().Value.ToString());
			FirstQueryDate = long.Parse(collection.Where(x => x.Key == "firstQueryDate").FirstOrDefault().Value.ToString());
		}
	}
}
