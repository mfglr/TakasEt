using Microsoft.IdentityModel.Tokens;

namespace AuthService.Core.Interfaces
{
    public interface ISignService
    {
        SigningCredentials GetSigningCredentials();
    }
}
