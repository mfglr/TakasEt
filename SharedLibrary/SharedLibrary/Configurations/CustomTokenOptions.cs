namespace SharedLibrary.Configurations
{
    public class CustomTokenOptions : ITokenOptions
    {
        public string Audience {  get; set; }
        public string Issuer { get; set;}
        public string SecurityKey { get; set; }
    }
}
