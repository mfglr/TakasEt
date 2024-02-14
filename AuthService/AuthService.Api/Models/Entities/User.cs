using Microsoft.AspNetCore.Identity;
using SharedLibrary.Extentions;
using System.Security.Cryptography;

namespace AuthService.Api.Entities
{
    public class User : IdentityUser
    {
        public User(string email,string userName)
        {
            UserName = userName;
            Email = email;
        }
        public void ConfirmEmail() => EmailConfirmed = true;


    }
}
