using Microsoft.AspNetCore.Http;

namespace Application.Extentions
{
	public static class FormCollectionExtentions
	{
		public static Stream? ReadStream(this IFormCollection collection)
		{
			if (collection.Files.Count() < 1)
				return null;
			return collection.Files[0].OpenReadStream();
		}
	}
}
