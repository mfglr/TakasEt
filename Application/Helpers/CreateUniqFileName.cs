namespace Application.Helpers
{
	public static class CreateUniqFileName
	{
		public static string RunHelper(int ownerId,string extention)
		{
			return $"{ownerId}-{DateTime.UtcNow.Ticks}-{Guid.NewGuid()}.{extention}";
		}
	}
}
