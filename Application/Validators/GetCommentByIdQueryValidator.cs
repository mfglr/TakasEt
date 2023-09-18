using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
	public class GetCommentByIdQueryValidator : AbstractValidator<GetCommentByIdRequestDto>
	{
        public GetCommentByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
