using Application.Dtos;
using FluentValidation;

namespace Application.Validators.PostImage
{
    public class GetPostImagesByPostIdQueryValidator : AbstractValidator<GetPostImagesByPostIdRequestDto>
	{
        public GetPostImagesByPostIdQueryValidator()
        {
            RuleFor(x => x.PostId).NotEmpty().NotNull().WithMessage("hata");
        }
    }
}
