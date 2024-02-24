using SharedLibrary.Dtos;
using SharedLibrary.Exceptions;
using System.Net;
using System.Net.Http.Json;

namespace SharedLibrary.Services
{
    public class UserAccountService
    {

        private readonly static string baseUrl = "https://localhost:7166/api/user";

        private HttpClient CreateHttpClient(string accessToken)
        {
            var client = new HttpClient() { BaseAddress = new Uri(baseUrl) };
            client.DefaultRequestHeaders.Add("Authorization", accessToken);
            return client;
        }

        public async Task<bool> IsBlocker(string userId,string accessToken,CancellationToken cancellationToken = default)
        {
            var client = CreateHttpClient(accessToken);
            var path = $"{baseUrl}/isblocker/{userId}";
            var response = await client.GetFromJsonAsync<ClientSideResponseDto<bool>>(path, cancellationToken);
            if (response == null)
                throw new AppException("error", HttpStatusCode.InternalServerError);
            if (response.IsError)
                throw new AppException(response.Errors, HttpStatusCode.BadRequest);
            return response.Data;
        }

        public async Task<bool> IsBlocked(string userId, string accessToken, CancellationToken cancellationToken = default)
        {
            var client = CreateHttpClient(accessToken);
            var path = $"{baseUrl}/isblocked/{userId}";
            var response = await client.GetFromJsonAsync<ClientSideResponseDto<bool>>(path, cancellationToken);
            if (response == null)
                throw new AppException("error", HttpStatusCode.InternalServerError);
            if (response.IsError)
                throw new AppException(response.Errors, HttpStatusCode.BadRequest);
            return response.Data;
        }

        public async Task<List<bool>> IsBlockerOrBlockedAsync(string userId, string accessToken, CancellationToken cancellationToken = default)
        {
            var client = CreateHttpClient(accessToken);
            var path = $"{baseUrl}/isblockerorblocked/{userId}";
            var response = await client.GetFromJsonAsync<ClientSideResponseDto<List<bool>>>(path, cancellationToken);
            if (response == null)
                throw new AppException("error", HttpStatusCode.InternalServerError);
            if (response.IsError)
                throw new AppException(response.Errors, HttpStatusCode.BadRequest);
            return response.Data;
        }

    }
}
