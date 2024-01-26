using AutoMapper;
using Models.Dtos;
using Models.Entities;

namespace Application.Mappers
{
    public class SingUpMapper : Profile
	{
        public SingUpMapper()
        {
            CreateMap<SignUpDto, User>();
			CreateMap<User, UserResponseDto>();
        }
    }
}
