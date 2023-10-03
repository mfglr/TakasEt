using Application.Dtos;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

namespace Function.Extentions
{
	internal static class FunctionContextExtentions
	{

		public static async Task WriteDataAsync(this FunctionContext context, byte[] data)
		{
			HttpResponseData response = (await context.GetHttpRequestDataAsync())!.CreateResponse();
			await response.WriteAsJsonAsync(data);
			response.StatusCode = HttpStatusCode.OK;
			context.GetInvocationResult().Value = response;
		}

		public static async Task WriteExceptionAsync(this FunctionContext context,string error,HttpStatusCode statusCode)
		{
			HttpResponseData response = (await context.GetHttpRequestDataAsync())!.CreateResponse();
			await response.WriteAsJsonAsync(
				AppResponseDto.Fail(error)
			);
			response.StatusCode = statusCode;
			context.GetInvocationResult().Value = response;
		}

		public static async Task WriteExceptionAsync(this FunctionContext context, List<string> errors, HttpStatusCode statusCode)
		{
			HttpResponseData response = (await context.GetHttpRequestDataAsync())!.CreateResponse();
			await response.WriteAsJsonAsync(
				AppResponseDto.Fail(errors)
			);
			response.StatusCode = statusCode;
			context.GetInvocationResult().Value = response;
		}

		public static async Task<string?> GetTokenAsync(this FunctionContext context)
		{
			string? headers = (string?)context.BindingContext.BindingData["Headers"];
			if (headers == null) return null;
			var authorization = JsonConvert.DeserializeObject<IReadOnlyDictionary<string, string>>(
				headers
			)?.GetValueOrDefault("Authorization");
			if (authorization == null) return null;
			return AuthenticationHeaderValue.Parse(authorization).Parameter;
		}
	}
}
