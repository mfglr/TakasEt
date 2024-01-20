using Application.Extentions;
using Microsoft.AspNetCore.Http;

namespace Application.Dtos
{
	public class Page
	{
        public int? Take { get; private set; }
		public int? LastId { get; private set; }

		public Page(IQueryCollection collection)
        {
			Take = collection.ReadInt("take");
			LastId = collection.ReadInt("lastId");
		}
	}
}
