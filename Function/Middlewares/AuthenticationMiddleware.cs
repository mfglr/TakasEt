using Application.Configurations;
using Application.Exceptions;
using Function.Attributes;
using Function.Extentions;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.IdentityModel.Tokens;
using Service;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Function.Middlewares
{
	public class AuthenticationMiddleware : IFunctionsWorkerMiddleware
	{
		private readonly JwtSecurityTokenHandler _jwtHandler;

		public AuthenticationMiddleware(JwtSecurityTokenHandler jwtHandler)
		{
			_jwtHandler = jwtHandler;
		}

		private void setCurrentUser(FunctionContext context,ClaimsPrincipal claimsPrincibal,SecurityToken token)
		{
			var currentUser = (CurrentUser?)context.InstanceServices.GetService(typeof(CurrentUser));
			currentUser?.Set(claimsPrincibal.GetId()!,claimsPrincibal.GetUserName()!,claimsPrincibal.GetEmail()!,token.ValidTo);
		}
	
		public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
		{
			AuthorizeAttribute? attribute = (AuthorizeAttribute?)context.FunctionDefinition.GetAttribute(typeof(AuthorizeAttribute));
			if (attribute != null)
			{
				var tokenValidatonParameters = (TokenValidationParameters?)context.InstanceServices.GetService(typeof(TokenValidationParameters));
				string? token = await context.GetTokenAsync();
				if(token == null) throw new TokenNotFoundException();
				var a = _jwtHandler.ReadJwtToken(token);
				ClaimsPrincipal claimsPrincipal = _jwtHandler.ValidateToken(token,tokenValidatonParameters,out var validatedToken);
				var rolesOfUser = claimsPrincipal.GetRoles();

				if (!attribute.HasRole(rolesOfUser)) throw new Application.Exceptions.UnauthorizedAccessException();
				setCurrentUser(context, claimsPrincipal, validatedToken);
			}
			await next(context);
		}
	}
}
