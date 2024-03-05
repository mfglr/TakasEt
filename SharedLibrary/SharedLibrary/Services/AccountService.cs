using Microsoft.AspNetCore.Http;
using SharedLibrary.Dtos;
using SharedLibrary.Exceptions;
using SharedLibrary.Extentions;
using System.Net;
using System.Net.Http.Json;

namespace SharedLibrary.Services
{
    public class AccountService
    {

        private readonly static string baseUrl = "https://localhost:7166/api/user";
        private readonly IHttpContextAccessor _contextAccessor;

        public AccountService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        private HttpClient CreateHttpClient(string accessToken)
        {
            var client = new HttpClient() { BaseAddress = new Uri(baseUrl) };
            client.DefaultRequestHeaders.Add("Authorization", accessToken);
            return client;
        }

        private string ThrowExceptionIfTokenNotExist()
        {
            var accessToken = _contextAccessor.HttpContext.GetAccessToken();
            return accessToken ?? throw new AppException("Token was not found", HttpStatusCode.Unauthorized);
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


        public async Task<bool> IsBlocker(string userId,CancellationToken cancellationToken = default)
        {

            var accessToken = ThrowExceptionIfTokenNotExist();

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

        public async Task<bool> IsBlocked(string userId,CancellationToken cancellationToken = default)
        {

            var accessToken = ThrowExceptionIfTokenNotExist();

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
                throw new AppException(response.Errors!, HttpStatusCode.BadRequest);
            return response.Data!;
        }

        public async Task<List<bool>> IsBlockerOrBlockedAsync(string userId, CancellationToken cancellationToken = default)
        {

            var accessToken = ThrowExceptionIfTokenNotExist();

            var client = CreateHttpClient(accessToken);
            var path = $"{baseUrl}/isblockerorblocked/{userId}";
            var response = await client.GetFromJsonAsync<ClientSideResponseDto<List<bool>>>(path, cancellationToken);
            if (response == null)
                throw new AppException("error", HttpStatusCode.InternalServerError);
            if (response.IsError)
                throw new AppException(response.Errors!, HttpStatusCode.BadRequest);
            return response.Data!;
        }




        public async Task<List<Guid>> GetBlockers(string accessToken, CancellationToken cancellationToken = default)
        {
            var client = CreateHttpClient(accessToken);
            var path = $"{baseUrl}/getblockers";
            var response = await client.GetFromJsonAsync<ClientSideResponseDto<List<Guid>>>(path, cancellationToken);

            if (response == null)
                throw new AppException("error", HttpStatusCode.InternalServerError);
            if (response.IsError)
                throw new AppException(response.Errors!, HttpStatusCode.BadRequest);
            return response.Data!;
        }

        public async Task<List<Guid>> GetBlockers(CancellationToken cancellationToken = default)
        {
            var accessToken = ThrowExceptionIfTokenNotExist();

            var client = CreateHttpClient(accessToken);
            var path = $"{baseUrl}/getblockers";
            var response = await client.GetFromJsonAsync<ClientSideResponseDto<List<Guid>>>(path, cancellationToken);

            if (response == null)
                throw new AppException("error", HttpStatusCode.InternalServerError);
            if (response.IsError)
                throw new AppException(response.Errors!, HttpStatusCode.BadRequest);
            return response.Data!;
        }

    }
}
