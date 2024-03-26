using FileStock.Core.Dtos;
using FileStock.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Dtos;
using SharedLibrary.Exceptions;
using SharedLibrary.Extentions;
using System.Net;

namespace FileStockWriter.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FileController : ControllerBase
    {

        private readonly IBlobService _blobService;

        public FileController(IBlobService blobService)
        {
            _blobService = blobService;
        }

        private string ThrowExceptionIfContainerNameIsNullOrEmpty(IFormCollection form)
        {
            var containerName = form.ReadString("containerName");
            return string.IsNullOrEmpty(containerName) ? 
                throw new AppException("A container name is required!", HttpStatusCode.BadRequest) : 
                containerName;
        }

        private void ThrowExceptionIfFilesAreEmpty(IFormCollection form)
        {
            if (form.Files.Count <= 0)
                throw new AppException("A file is required!", HttpStatusCode.BadRequest);
        }


        [Authorize(Roles = "user")]
        [HttpPost]
        public async Task<IAppResponseDto> UploadImageFile([FromForm] IFormCollection form, CancellationToken cancellationToken)
        {
            ThrowExceptionIfFilesAreEmpty(form);
            var containerName = ThrowExceptionIfContainerNameIsNullOrEmpty(form);
            var file = form.Files.First();
            
            return new AppGenericSuccessResponseDto<ImageFileDto>(
                await _blobService.UploadImageFileAsync(file, containerName, cancellationToken)
                );
        }

        [Authorize(Roles = "user")]
        [HttpPost]
        public async Task<IAppResponseDto> UploadImageFiles([FromForm] IFormCollection form, CancellationToken cancellationToken)
        {
            ThrowExceptionIfFilesAreEmpty(form);
            var containerName = ThrowExceptionIfContainerNameIsNullOrEmpty(form);

            return new AppGenericSuccessResponseDto<List<ImageFileDto>>(
                await _blobService.UploadImageFilesAsync(form.Files, containerName, cancellationToken)
                );
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{containerName}/{blobName}")]
        public IAppResponseDto DeleteFile(string containerName, string blobName)
        {
            _blobService.Delete(containerName, blobName);
            return new AppSuccessResponseDto();
        }

    }
}
