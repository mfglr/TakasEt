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
		private readonly CustomTokenOptions _customTokenOptions;
		private readonly SignService _signService;

		public AuthenticationMiddleware(
			JwtSecurityTokenHandler jwtHandler,
			CustomTokenOptions customTokenOptions,
			SignService signService)
		{
			_jwtHandler = jwtHandler;
			_customTokenOptions = customTokenOptions;
			_signService = signService;
		}

		private void setCurrentUser(FunctionContext context,ClaimsPrincipal claimsPrincibal,SecurityToken token)
		{
			var currentUser = (CurrentUser?)context.InstanceServices.GetService(typeof(CurrentUser));
			currentUser?.Set(
				claimsPrincibal.Claims.SingleOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier)!.Value,
				claimsPrincibal.Claims.SingleOrDefault(claim => claim.Type == ClaimTypes.Name)!.Value,
				claimsPrincibal.Claims.SingleOrDefault(claim => claim.Type == ClaimTypes.Email)!.Value,
				token.ValidTo
			);
		}
	
		public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
		{
			if (context.FunctionDefinition.HasCustomAttribute(typeof(AuthorizeAttribute)))
			{
				var tokenValidatonParameters = (TokenValidationParameters?)context.InstanceServices.GetService(typeof(TokenValidationParameters));
				string? token = await context.GetTokenAsync();
				if(token == null) throw new TokenNotFoundException();
				var a = _jwtHandler.ReadJwtToken(token);
				ClaimsPrincipal claimsPrincibal = _jwtHandler.ValidateToken(token,tokenValidatonParameters,out var validatedToken);
				setCurrentUser(context, claimsPrincibal,validatedToken);
			}
			await next(context);
		}
	}
}
