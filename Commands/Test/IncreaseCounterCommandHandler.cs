using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Commands
{
    public class IncreaseCounterCommandHandler : IRequestHandler<IncreateCounter, AppResponseDto>
    {
        private readonly IRepository<Test> _tests;

        public IncreaseCounterCommandHandler(IRepository<Test> tests)
        {
            _tests = tests;
        }

        public async Task<AppResponseDto> Handle(IncreateCounter request, CancellationToken cancellationToken)
        {
            var test = await _tests.DbSet.FirstAsync(x => x.Id == 1);
            test.IncreaseCounter();
            return AppResponseDto.Success();
        }
    }
}
