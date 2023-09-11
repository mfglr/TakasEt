using Application.Exceptions;
using Function.Extentions;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.IdentityModel.Tokens;
using System.Net;

namespace Function.Middlewares
{
	public class ExceptionMiddleware : IFunctionsWorkerMiddleware
	{
		public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
		{
			try
			{
				await next(context);
				Console.WriteLine("ali");
			}
			catch (SystemException ex){
				await context.WriteExceptionAsync(
					$"Server side exception!!!\nType : {ex.GetType()}\nMessage : {ex.Message}",
					HttpStatusCode.InternalServerError
				);
			}
			catch(SecurityTokenException ex)
			{
				await context.WriteExceptionAsync(
					$"Unauthorized : {ex.Message}\nType : {ex.GetType()}\nMessage : {ex.Message}",
					HttpStatusCode.Unauthorized
					);
			}
			catch (CustomException ex)
			{
				await context.WriteExceptionAsync(ex.Message, ex.StatusCode);
			}

		}
	}
}
