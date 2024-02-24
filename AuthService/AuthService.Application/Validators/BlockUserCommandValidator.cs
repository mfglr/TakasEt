using AuthService.Application.Dtos;
using FluentValidation;

namespace AuthService.Application.Validators
{
    public class BlockUserCommandValidator : AbstractValidator<BlockUserDto>
    {
        public BlockUserCommandValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty().WithMessage("User id is required!");
        }

    }
}
