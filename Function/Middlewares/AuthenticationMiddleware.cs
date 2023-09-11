using Application.Configurations;
using Application.Entities;
using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
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

		private TokenValidationParameters CreateTokenValidationParameters(CustomTokenOptions customTokenOptions,SignService signService)
		{
			return new TokenValidationParameters()
			{
				ValidIssuer = customTokenOptions.Issuer,
				ValidAudience = customTokenOptions.Audiences[0],
				IssuerSigningKey = signService.GetSymmetricSecurityKey(customTokenOptions.SecurityKey),
				ValidateIssuer = true,
				ValidateIssuerSigningKey = true,
				ValidateAudience = true,
				ValidateLifetime = true,
				ClockSkew = TimeSpan.Zero
			};
		} 
	
		public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
		{
			if (context.FunctionDefinition.HasCustomAttribute(typeof(AuthorizeAttribute)))
			{
				string? token = await context.GetTokenAsync();
				if(token == null) throw new TokenNotFoundException();
				
				ClaimsPrincipal cliamsPrincibal = _jwtHandler.ValidateToken(
					token,
					CreateTokenValidationParameters(_customTokenOptions, _signService),
					out var validatedToken
				);
			}
			await next(context);
			return;
		}
	}
}
