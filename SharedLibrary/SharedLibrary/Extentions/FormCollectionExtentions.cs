using Microsoft.AspNetCore.Http;

namespace SharedLibrary.Extentions
{
	public static class FormCollectionExtentions
	{
		public static Stream? ReadStream(this IFormCollection collection)
		{
			if (collection.Files.Count() < 1)
				return null;
			return collection.Files[0].OpenReadStream();
		}

		public static IReadOnlyList<Stream> ReadStreams(this IFormCollection collection)
		{
			return collection.Files.Select(x => x.OpenReadStream()).ToList();
		}
	}
}
