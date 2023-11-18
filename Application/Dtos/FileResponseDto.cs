using Application.Dtos.AppFile;

namespace Application.Dtos
{
	public class FileResponseDto : BaseResponseDto
	{
        public IEnumerable<AppFileResponseDto> AppFiles { get; set; }

    }
}
