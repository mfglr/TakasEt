using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
	public class GetActiveProfileImageByUserIdQueryValidator : AbstractValidator<GetActiveProfileImageByIdRequestDto>
	{
        public GetActiveProfileImageByUserIdQueryValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("hata");
        }
    }
}
