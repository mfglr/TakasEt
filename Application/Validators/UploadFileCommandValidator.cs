using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
	public class UploadFileCommandValidator : AbstractValidator<UploadFileRequestDto>
	{
        public UploadFileCommandValidator()
        {
            RuleFor(x => x.OwnerId).NotEmpty().NotNull().WithMessage("hata");
			RuleFor(x => x.Extentions).NotEmpty().NotNull().WithMessage("hata");
			RuleFor(x => x.ContainerName).NotEmpty().NotNull().WithMessage("hata");
		}
	}
}
