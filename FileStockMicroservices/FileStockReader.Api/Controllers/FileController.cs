using FileStock.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FileStockReader.Api.Controllers
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

        [Authorize(Roles = "user")]
        [HttpGet("{containerName}/{blobName}")]
        public async Task<FileContentResult> DownloadFile(string containerName, string blobName, CancellationToken cancellationToken)
        {
            return File(
                await _blobService.DownloadAsync(containerName, blobName, cancellationToken),
                "application/octet-stream"
            );
        }
    }
}
