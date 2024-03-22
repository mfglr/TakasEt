using Microsoft.AspNetCore.Http;
using SharedLibrary.Configurations;
using SharedLibrary.Dtos;
using SharedLibrary.Exceptions;
using SharedLibrary.Extentions;
using System.Net;
using System.Net.Http.Json;

namespace SharedLibrary.Services
{
    public class PhotoStockService
    {
        private readonly IMicroservices _microservices;
        private readonly IHttpContextAccessor _contextAccessor;

        public PhotoStockService(IMicroservices microservices, IHttpContextAccessor contextAccessor)
        {
            _microservices = microservices;
            _contextAccessor = contextAccessor;
        }


        private HttpClient CreateHttpClient()
        {
            var accessToken = _contextAccessor.HttpContext.GetAccessToken();
            var client = new HttpClient() { BaseAddress = new Uri(_microservices.PhotoStockMicroservice) };
            client.DefaultRequestHeaders.Add("Authorization", accessToken);
            return client;
        }


        public async Task<List<ImageResponDto>> UploadFilesAsync(IFormFileCollection files, CancellationToken cancellationToken = default)
        {
            var httpClient = CreateHttpClient();
            var url = $"{_microservices.PhotoStockMicroservice}/image/UploadImages";
            
            var response = await httpClient.GetFromJsonAsync<ClientSideResponseDto<List<ImageResponDto>>>(url, cancellationToken);

            if (response == null)
                throw new AppException("error", HttpStatusCode.InternalServerError);

            if (response.IsError)
                throw new AppException(response.Errors!, (HttpStatusCode)response.StatusCode!);

            return response.Data!;
        }

    }
}
