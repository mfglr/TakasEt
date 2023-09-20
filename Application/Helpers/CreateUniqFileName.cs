namespace Application.Helpers
{
	public static class CreateUniqFileName
	{
		public static string RunHelper(Guid ownerId,string extention)
		{
			return $"{ownerId}-{DateTime.UtcNow.ToString("dddd dd MMMM hh:mm:ss.FFFFFFF")}-{Guid.NewGuid()}.{extention}";
		}
	}
}
