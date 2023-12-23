using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class Pagination
	{
        public int Take { get; set; }
		public int? LastId { get; set; }

		public Pagination(IQueryCollection collection)
        {
			Take = int.Parse(collection.Where(x => x.Key == "take").FirstOrDefault().Value.ToString());
			string lastId = collection.Where(x => x.Key == "lastId").FirstOrDefault().Value.ToString();
			if (lastId != "")
				LastId = int.Parse(lastId);
			else
				LastId = null;
		}
	}
}
