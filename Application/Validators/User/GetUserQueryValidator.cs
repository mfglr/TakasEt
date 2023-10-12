using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
    public class GetUserQueryValidator : AbstractValidator<GetUser>
	{
        public GetUserQueryValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("hata");
        }
    }
}
