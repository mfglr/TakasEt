using AutoMapper;
using Dto.SignUp;
using Model.Entities;

namespace Application.Mappers
{
	public class SingUpMapper : Profile
	{
        public SingUpMapper()
        {
            CreateMap<SignUpCommandRequestDto, User>();
            CreateMap<User,SignUpCommandResponseDto>();
        }
    }
}
