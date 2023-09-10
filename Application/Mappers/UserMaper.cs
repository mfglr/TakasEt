using Application.Dtos;
using Application.Entities;
using AutoMapper;

namespace Application.Mappers
{
	public class UserMaper : Profile
	{
        public UserMaper()
        {
            CreateMap<User, UserResponseDto>();
        }
    }
}
