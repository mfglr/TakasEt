namespace Application.Configuration
{
	public class Local
	{
		public string SqlConnectionString { get; private set; }
		public string BaseUrlOfApi {  get; private set; }

		public Local(string sqlConnectionString, string baseUrlOfApi)
		{
			SqlConnectionString = sqlConnectionString;
			BaseUrlOfApi = baseUrlOfApi;
		}
	}
}
