using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
    public class GetActiveProfileImageQueryValidator : AbstractValidator<GetActiveProfileImage>
    {
        public GetActiveProfileImageQueryValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("hata");
        }
    }
}
