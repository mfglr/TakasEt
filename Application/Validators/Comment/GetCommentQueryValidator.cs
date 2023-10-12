using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
    public class GetCommentQueryValidator : AbstractValidator<GetComment>
    {
        public GetCommentQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
