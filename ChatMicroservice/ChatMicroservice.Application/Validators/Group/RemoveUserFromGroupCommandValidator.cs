using ChatMicroservice.Application.Dtos.Group;
using ChatMicroservice.Core.Interfaces;
using ChatMicroservice.Infrastructure;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;

namespace ChatMicroservice.Application.Validators
{
	public class RemoveUserFromGroupCommandValidator : AbstractValidator<RemoveUserFromGroupDto>
	{
		public RemoveUserFromGroupCommandValidator()
		{
			RuleFor(x => x.UserId).NotNull().WithMessage("error");
			RuleFor(x => x.GrupId).NotNull().WithMessage("error");
			RuleFor(x => x.RemoverId).NotNull().WithMessage("error");
		}
	}
}
