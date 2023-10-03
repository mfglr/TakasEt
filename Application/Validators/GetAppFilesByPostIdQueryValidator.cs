using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
    public class GetAppFilesByPostIdQueryValidator : AbstractValidator<GetPostImagesByPostIdRequestDto>
	{
        public GetAppFilesByPostIdQueryValidator()
        {
            RuleFor(x => x.PostId).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
