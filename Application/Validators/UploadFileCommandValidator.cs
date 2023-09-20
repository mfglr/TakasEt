using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
	public class UploadFileCommandValidator : AbstractValidator<UploadFileRequestDto>
	{
        public UploadFileCommandValidator()
        {
            RuleFor(x => x.OwnerId).NotEmpty().NotNull().WithMessage("hata");
			RuleFor(x => x.Extention).NotEmpty().NotNull().WithMessage("hata");
			RuleFor(x => x.FileType).NotEmpty().NotNull().WithMessage("hata");
		}
	}
}
