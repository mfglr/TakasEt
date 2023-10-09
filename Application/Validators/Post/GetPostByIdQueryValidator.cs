using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
    public class GetPostByIdQueryValidator : AbstractValidator<GetPostByIdRequestDto>
    {
        public GetPostByIdQueryValidator()
        {
            RuleFor(x => x.PostId).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
