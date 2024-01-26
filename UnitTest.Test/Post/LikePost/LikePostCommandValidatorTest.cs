using Application.Interfaces.Repositories;
using Application.Validators;
using Models.Dtos;
using Models.Entities;
using Repository.Contexts;
using Repository.Repositories;
using Xunit;

namespace UnitTest.Test
{
	public class LikePostCommandValidatorTest
	{
        private readonly LIkePostCommandValidator validator;
        private readonly AppDbContext appDbContext;
        private readonly IRepository<PostUserLiking> userPostLikings;
        private readonly IRepository<User> users;
        private readonly IRepository<Post> posts;

        public LikePostCommandValidatorTest()
        {
            appDbContext = new AppDbContext(DbContextOptionFactory.DbContextOptions);
            userPostLikings = new Repository<PostUserLiking>(appDbContext);
            users = new Repository<User>(appDbContext);
            posts = new Repository<Post>(appDbContext);
            validator = new LIkePostCommandValidator(userPostLikings, users, posts);
        }

        [Theory]
        [InlineData(null,null)]
        [InlineData(null,5)]
        [InlineData(5,null)]
        public async Task LikePostCommandValidator_NullValues_ReturnInvalid(int? loggedInUserId,int? postId)
        {
            var request = new LikePostDto(loggedInUserId, postId);
            var result = await validator.ValidateAsync(request);
            Assert.False(result.IsValid);
        }

		[Theory]
		[InlineData(5, 0)]
		public async Task LikePostCommandValidator_WhenPostIdNotExistInDb_ReturnInvalid(int? loggedInUserId, int? postId)
		{
			var request = new LikePostDto(loggedInUserId, postId);
			var result = await validator.ValidateAsync(request);
			Assert.False(result.IsValid);
		}

		[Theory]
		[InlineData(0, 5)]
		public async Task LikePostCommandValidator_WhenLoggedInUserIdNotExistInDb_ReturnInvalid(int? loggedInUserId, int? postId)
		{
			var request = new LikePostDto(loggedInUserId, postId);
			var result = await validator.ValidateAsync(request);
			Assert.False(result.IsValid);
		}

		[Theory]
		[InlineData(5, 5)]
		public async Task LikePostCommandValidator_WhenUserAlreadyLikePost_ReturnInvalid(int? loggedInUserId, int? postId)
		{
			var request = new LikePostDto(loggedInUserId, postId);
			var result = await validator.ValidateAsync(request);
			Assert.False(result.IsValid);
		}

		[Theory]
		[InlineData(4, 4)]
		public async Task LikePostCommandValidator_WhenUserNotLikePost_ReturnValid(int? loggedInUserId, int? postId)
		{
			var request = new LikePostDto(loggedInUserId, postId);
			var result = await validator.ValidateAsync(request);
			Assert.True(result.IsValid);
		}

	}
}
