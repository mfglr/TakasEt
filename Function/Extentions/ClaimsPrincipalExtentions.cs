using System.Security.Claims;

namespace Function.Extentions
{
	public static class ClaimsPrincipalExtentions
	{
		private static string? getString(ClaimsPrincipal claimsPrincipal,Func<Claim,bool> predicate)
		{
			return claimsPrincipal
					.Claims
					.SingleOrDefault(predicate)?
					.Value;

		}
		private static IEnumerable<string>? getListString(ClaimsPrincipal claimsPrincipal, Func<Claim, bool> predicate)
		{
			return claimsPrincipal
					.Claims
					.SingleOrDefault(predicate)?
					.Value
					.Split(",");
		}
		public static IEnumerable<string>? GetRoles(this ClaimsPrincipal claimsPrincipal)
		{
			return getListString(claimsPrincipal, claim => claim.Type == ClaimTypes.Role);
		}
		public static string? GetId(this ClaimsPrincipal claimsPrincipal)
		{
			return getString(claimsPrincipal,claim => claim.Type == ClaimTypes.NameIdentifier);
		}
		public static string? GetUserName(this ClaimsPrincipal claimsPrincipal)
		{
			return getString(claimsPrincipal, claim => claim.Type == ClaimTypes.Name);
		}
		public static string? GetEmail(this ClaimsPrincipal claimsPrincipal)
		{
			return getString(claimsPrincipal, claim => claim.Type == ClaimTypes.Email);
		}
	}
}
