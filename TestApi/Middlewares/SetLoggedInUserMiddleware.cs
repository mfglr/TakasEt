using Application.Configurations;
using System.Security.Claims;

namespace Function.Middlewares
{
	public class SetLoggedInUserMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly LoggedInUser _loggedInUser;
		public SetLoggedInUserMiddleware(RequestDelegate next, LoggedInUser loggedInUser)
		{
			_next = next;
			_loggedInUser = loggedInUser;
		}

		public async Task Invoke(HttpContext context)
		{
			//Set Login in userId;
			var accessToken = context.Request.Headers.Authorization.ToString();
			if (accessToken != null && accessToken != "") { 
				var id = context.User.Claims.SingleOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
				if (id != null)
				{
					_loggedInUser.SetUserId(int.Parse(id));

				}
			}
			await _next.Invoke(context);
		}
	}
}
