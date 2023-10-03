using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
	public class GetAppFileByKeyQueryValidator : AbstractValidator<GetAppFileByKeyRequestDto>
	{
        public GetAppFileByKeyQueryValidator()
        {
            RuleFor(x => x.ContainerName).NotEmpty().NotNull().WithMessage("hata");
			RuleFor(x => x.BlobName).NotEmpty().NotNull().WithMessage("hata");
		}
	}
}
