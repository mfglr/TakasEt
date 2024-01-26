using Microsoft.AspNetCore.Http;

namespace Models.Extentions
{
	public static class FormCollectionExtentions
	{
		public static Stream? ReadStream(this IFormCollection collection)
		{
			if (collection.Files.Count() < 1)
				return null;
			return collection.Files[0].OpenReadStream();
		}

		public static IReadOnlyCollection<Stream>? ReadStreams(this IFormCollection collection)
		{
			if(collection.Files.Count() < 1) return null;
			return collection.Files.Select(x => x.OpenReadStream()).ToList();
		}
	}
}
