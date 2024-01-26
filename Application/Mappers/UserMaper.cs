using AutoMapper;
using Models.Dtos;
using Models.Entities;

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
