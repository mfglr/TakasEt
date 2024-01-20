using Application.Dtos;
using MediatR;
using WebApi.Controllers;
using Xunit;

namespace UnitTest.Test
{
	public class LikePostTest
	{
		private readonly IRequestHandler<LikePostDto, AppResponseDto> _handler;
		private readonly PostController _postController;

		public LikePostTest(IRequestHandler<LikePostDto, AppResponseDto> handler)
		{
			//_handler = handler;
			//_postController = new PostController()
		}



		//[Theory]
		//[InlineData()]
		//public void LikePost_(LikePostDto request)
		//{
		//	Assert.True(true);
		//}

	}
}
