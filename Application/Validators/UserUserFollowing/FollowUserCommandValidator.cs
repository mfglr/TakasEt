using Application.Configurations;
using Application.Dtos;
using FluentValidation;

namespace Application.Validators
{
    public class FollowUserCommandValidator : AbstractValidator<FollowUser>
    {

		private readonly LoggedInUser _loggedInUser;
		public FollowUserCommandValidator(LoggedInUser loggedInUser)
		{
			_loggedInUser = loggedInUser;
			RuleFor(x => x.FollowedId).NotEmpty().NotNull().WithMessage("hata");
			RuleFor(x => x.FollowedId).NotEqual(_loggedInUser.UserId).WithMessage("hata");
		}

	}
}
