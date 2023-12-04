using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Handler.Commands
{
	public class ChangeNameCommandHandler : IRequestHandler<ChangeName, AppResponseDto>
	{
		private readonly IRepository<Test> _tests;

		public ChangeNameCommandHandler(IRepository<Test> tests)
		{
			_tests = tests;
		}

		public async Task<AppResponseDto> Handle(ChangeName request, CancellationToken cancellationToken)
		{
			var test = await _tests.DbSet.FirstAsync(x => x.Id == 1);
			test.ChangeName();
			return AppResponseDto.Success();
		}
	}
}
