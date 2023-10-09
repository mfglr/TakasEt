using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
    public class RemoveUserCommandValidator : AbstractValidator<RemoveUserRequestDto>
    {
        public RemoveUserCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
