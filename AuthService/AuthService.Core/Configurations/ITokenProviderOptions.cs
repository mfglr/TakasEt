namespace AuthService.Core.Configurations
{
    public interface ITokenProviderOptions
    {
        List<string> Audiences { get; }
        string Issuer { get; }
        int AccessTokenExpiration { get; }
        int RefreshTokenExpiration { get; }
        string SecurityKey { get; }
    }
}
