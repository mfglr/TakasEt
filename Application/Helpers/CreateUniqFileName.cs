namespace Application.Helpers
{
	public static class CreateUniqFileName
	{
		public static string RunHelper(string extention)
		{
			return $"{DateTime.UtcNow.Ticks}-{Guid.NewGuid()}.{extention}";
		}
	}
}
