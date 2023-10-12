using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
    public class GetAppFileQueryValidator : AbstractValidator<GetAppFile>
    {
        public GetAppFileQueryValidator()
        {
            RuleFor(x => x.ContainerName).NotEmpty().NotNull().WithMessage("hata");
            RuleFor(x => x.BlobName).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
