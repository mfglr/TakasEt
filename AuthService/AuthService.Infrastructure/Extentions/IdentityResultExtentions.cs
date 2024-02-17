using Microsoft.AspNetCore.Identity;

namespace AuthService.Infrastructure.Extentions
{
    public static class IdentityResultExtentions
    {
        public static List<string> GetErrors(this IdentityResult result)
        {
            return result.Errors.Select(x => x.Description).ToList();
        }

    }
}
