using Microsoft.AspNetCore.Http;
using SharedLibrary.Dtos;
using SharedLibrary.Exceptions;
using SharedLibrary.Extentions;
using System.Net;
using System.Net.Http.Json;

namespace SharedLibrary.Services
{
    public class UserService
    {
        private readonly static string baseUrl = "https://localhost:7267/api/user";
        private readonly IHttpContextAccessor _contextAccessor;

        public UserService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        private HttpClient CreateHttpClient(string accessToken)
        {
            var client = new HttpClient() { BaseAddress = new Uri(baseUrl) };
            client.DefaultRequestHeaders.Add("Authorization", accessToken);
            return client;
        }

        public async Task<List<UserResponseDto>> GetUsersByIds(
            List<Guid> ids,
            CancellationToken cancellationToken = default
        )
        {

            var accessToken = _contextAccessor.HttpContext.GetAccessToken()!;
            var client = CreateHttpClient(accessToken);
            var path = $"{baseUrl}/GetUsersByIds?ids={string.Join(",",ids)}";
            var response = await client.GetFromJsonAsync<ClientSideResponseDto<List<UserResponseDto>>>(path, cancellationToken);

            if (response == null)
                throw new AppException("error", HttpStatusCode.InternalServerError);

            if (response.IsError)
                throw new AppException(response.Errors!, HttpStatusCode.BadRequest);
            return response.Data!;

        }

    }
}
