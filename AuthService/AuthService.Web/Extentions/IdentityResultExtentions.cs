using Microsoft.AspNetCore.Identity;

namespace AuthService.Web.Extentions
{
    internal static class IdentityResultExtentions
    {
        public static List<string> GetErrors(this IdentityResult result)
        {
            return result.Errors.Select(x => x.Description).ToList();
        }

    }
}
