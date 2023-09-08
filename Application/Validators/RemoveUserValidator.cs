using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
	public class RemoveUserValidator : AbstractValidator<RemoveUserRequestDto>
	{
        public RemoveUserValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
