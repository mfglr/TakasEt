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
			}
			catch (CustomException ex)
			{
				await context.WriteExceptionAsync(ex.Message, ex.StatusCode);
			}
			catch (SystemException ex)
			{
				await context.WriteExceptionAsync(
					$"Server side exception!!!\nType : {ex.GetType()}\nMessage : {ex.Message}",
					HttpStatusCode.InternalServerError
				);
			}
			catch (SecurityTokenException ex)
			{
				await context.WriteExceptionAsync(
					$"Unauthorized : {ex.Message}\nType : {ex.GetType()}\nMessage : {ex.Message}",
					HttpStatusCode.Unauthorized
					);
			}
			catch (Exception ex)
			{
				if (ex is AggregateException aggregateException)
				{
					Exception? innerException = aggregateException.InnerException;
					if (innerException is CustomException customException)
						await context.WriteExceptionAsync(ex.Message, customException.StatusCode);
					else
					{
						await context.WriteExceptionAsync(
							$"Undefined Exception!\nType : {innerException?.GetType()}\nMessage : {innerException?.Message}",
							HttpStatusCode.BadRequest
						);
					}
				}
				else
				{
					await context.WriteExceptionAsync(
						$"Undefined Exception!\nType : {ex.GetType()}\nMessage : {ex.Message}",
						HttpStatusCode.BadRequest
					);
				}
			}

		}
	}
}
