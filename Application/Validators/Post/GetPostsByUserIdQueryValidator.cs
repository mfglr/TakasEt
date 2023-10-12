using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
	public class GetPostsByUserIdQueryValidator : AbstractValidator<GetPostsByUserId>
	{
        public GetPostsByUserIdQueryValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
