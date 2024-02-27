namespace UserService.Api.Configurations
{
    public interface ITokenOptions
    {
        string Audience { get; }
        string Issuer { get; }
        string SecurityKey { get; }
    }
}
