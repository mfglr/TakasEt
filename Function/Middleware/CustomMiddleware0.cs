using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Middleware;

namespace Function.Middleware
{
	public class CustomMiddleware0 : IFunctionsWorkerMiddleware
	{
		public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
		{
			Console.WriteLine("deneme");
			await next(context);
			
		}
	}
}
