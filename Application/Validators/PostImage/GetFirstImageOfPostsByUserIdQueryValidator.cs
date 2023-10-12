using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
    public class GetFirstImageOfPostsByUserIdQueryValidator : AbstractValidator<GetFirstImagesOfPostsByUserId>
	{
        public GetFirstImageOfPostsByUserIdQueryValidator()
        {
            RuleFor(x  => x.UserId).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
