using Application.Dtos;

namespace Application.Dtos
{
    public class DownloadFileResponseDto : BaseResponseDto
    {
        public byte[] bytes { get; set; }
    }
}
