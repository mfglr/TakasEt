namespace SharedLibrary.Configurations
{
    public interface ITokenConfiguration
    {
        List<string> Audiences { get; }
        string Issuer {  get; }
        int AccessTokenExpiration { get; }
        int RefreshTokenExpiration { get; }
        string SecurityKey { get; }
    }
}
