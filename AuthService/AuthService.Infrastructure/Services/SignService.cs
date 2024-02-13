using AuthService.Core.Interfaces;
using Microsoft.IdentityModel.Tokens;
using SharedLibrary.Configurations;
using System.Text;

namespace AuthService.Infrastructure.Services
{

    public class SignService : ISignService
    {

        private readonly ITokenConfiguration _tokenConfiguration;

        public SignService(ITokenConfiguration tokenConfiguration)
        {
            _tokenConfiguration = tokenConfiguration;
        }

        public SigningCredentials GetSigningCredentials()
        {
            return new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenConfiguration.SecurityKey)),
                SecurityAlgorithms.HmacSha256Signature
            );
        }
    }
}
