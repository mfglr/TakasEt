using Application.Dtos.SignUp;
using Application.Entities;
using AutoMapper;

namespace Application.Mappers
{
	public class SingUpMapper : Profile
	{
        public SingUpMapper()
        {
            CreateMap<SignUpCommandRequestDto, User>();
			CreateMap<User, SignUpCommandResponseDto>();
        }
    }
}
