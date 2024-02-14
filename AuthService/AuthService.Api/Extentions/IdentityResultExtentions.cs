using Microsoft.AspNetCore.Identity;

namespace AuthService.Api.Extentions
{
    public static class IdentityResultExtentions
    {
        public static string GetErrors(this IdentityResult result)
        {
            return string.Join("\n", result.Errors.Select(x => x.Description).ToList());
        }

    }
}
