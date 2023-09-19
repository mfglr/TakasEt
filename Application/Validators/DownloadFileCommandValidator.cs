using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
	public class DownloadFileCommandValidator : AbstractValidator<DownloadFileRequestDto>
	{
        public DownloadFileCommandValidator()
        {
            RuleFor(x => x.ContainerName).NotEmpty().NotNull().WithMessage("hata");
			RuleFor(x => x.BlobName).NotEmpty().NotNull().WithMessage("hata");
		}
	}
}
