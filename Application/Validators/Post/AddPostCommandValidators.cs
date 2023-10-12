using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
    public class AddPostCommandValidators : AbstractValidator<AddPost>
    {
        public AddPostCommandValidators()
        {
            RuleFor(x => x.Title).NotEmpty().NotNull().WithMessage("hata");
            RuleFor(x => x.Content).NotEmpty().NotNull().WithMessage("hata");
            RuleFor(x => x.CategoryId).NotEmpty().NotNull().WithMessage("hata");
			RuleFor(x => x.Extentions).NotEmpty().NotNull().WithMessage("hata");
            RuleFor(x => x.Streams.Count).GreaterThan(0).WithMessage("hata");
		}
	}
}
