using Application.Configurations;
using Function.Attributes;
using Function.Extentions;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Service;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Reflection;
using System.Reflection.PortableExecutable;

namespace Function.MiddleWares
{
	public class CustomMiddleware : IFunctionsWorkerMiddleware
	{
		private readonly JwtSecurityTokenHandler _jwtHandler;
		private readonly CustomTokenOptions _customTokenOptions;
		private readonly SignService _signService;

		public CustomMiddleware(
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
				var authorization = JsonConvert.DeserializeObject<IReadOnlyDictionary<string, string>>(
						(string)context.BindingContext.BindingData["Headers"]
					).GetValueOrDefault("Authorization");

				if (authorization == null) throw new Exception("hata");
				
				string token = AuthenticationHeaderValue.Parse(authorization).Parameter;

				try
				{
					var cliamsPrincibal = _jwtHandler.ValidateToken(
						token,
						CreateTokenValidationParameters(_customTokenOptions, _signService),
						out var validatedToken
					);
					Console.WriteLine("");
				}
				catch (Exception ex)
				{
					Console.WriteLine("hata");
					return;
				}

			}
			await next(context);
			return;
		}
	}
}
