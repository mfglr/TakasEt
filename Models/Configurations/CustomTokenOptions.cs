namespace Models.Configurations
{
	public class CustomTokenOptions
	{
		public List<string> Audiences { get; set; }
		public string Issuer { get; set; }
		public int ExprationOfAccessToken { get; set; }
		public int ExprationOfRefreshToken { get; set; }
		public string SecurityKey { get; set; }
	}
}
