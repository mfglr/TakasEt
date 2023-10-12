using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
    public class GetPostImagesQueryValidator : AbstractValidator<GetPostImages>
	{
        public GetPostImagesQueryValidator()
        {
            RuleFor(x => x.PostId).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
