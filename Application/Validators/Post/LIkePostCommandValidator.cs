using Models.Interfaces.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Models.Dtos;
using Models.Entities;

namespace Application.Validators
{
    public class LIkePostCommandValidator : AbstractValidator<LikePostDto>
    {
        public LIkePostCommandValidator(
            IRepository<PostUserLiking> userPostLikings,
            IRepository<User> users,
            IRepository<Post> posts
        )
        {
			RuleFor(x => x.PostId).NotNull().WithMessage("error");
            RuleFor(x => x.LoggedInUserId).NotNull().WithMessage("error");
            
            RuleFor(x => x.LoggedInUserId)
                .MustAsync(
                    async (userId, cancellationToken) =>
                    {
                        return await users.DbSet.AnyAsync(x => x.Id == userId,cancellationToken);
                    }
                )
                .WithMessage("error");

            RuleFor(x => x.PostId)
                .MustAsync(
                        async (postId, cancellationToken) =>
                        {
                            return await posts.DbSet.AnyAsync(x => x.Id == postId,cancellationToken);
                        }
                    )
                .WithMessage("error");

            RuleFor(x => x)
                .MustAsync(
                    async (request,cancellationToken) =>
                    {
                        return await userPostLikings.DbSet.FindAsync(request.LoggedInUserId,request.PostId, cancellationToken) == null;
                    }
                )
                .WithMessage("error");
        }
    }
}
