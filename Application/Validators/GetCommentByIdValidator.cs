using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
	public class GetCommentByIdValidator : AbstractValidator<GetCommentByIdRequestDto>
	{
        public GetCommentByIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
