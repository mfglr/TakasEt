using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Pipelines;
using Commands;
using Models.Dtos;
using Models.Entities;
using Repository.Contexts;

namespace UnitTest.Test
{
	public class LikePostCommandHandlerTest
	{
		private readonly LikePostCommadHandler handler;
		private readonly AppDbContext context;
		private readonly IRepository<Post> posts;
		private readonly IUnitOfWork unitOfWork;

		private readonly AppPipelineBehavior<LikePostDto, AppResponseDto> appPipeline;

		public LikePostCommandHandlerTest()
		{

			
		}

		

	}
}
