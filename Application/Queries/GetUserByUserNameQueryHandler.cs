using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries
{
    public class GetUserByUserNameQueryHandler : IRequestHandler<GetUserByUserNameRequestDto, UserResponseDto>
    {
        private readonly IRepository<User> _users;
        private readonly IMapper _mapper;

        public GetUserByUserNameQueryHandler(IRepository<User> users, IMapper mapper)
        {
            _users = users;
            _mapper = mapper;
        }

        public async Task<UserResponseDto> Handle(GetUserByUserNameRequestDto request, CancellationToken cancellationToken)
        {
            var user = await _users.DbSet.SingleOrDefaultAsync(x => x.UserName == request.UserName);
            if (user == null) throw new Exception("hata");
            return _mapper.Map<UserResponseDto>(user);
        }
    }
}
