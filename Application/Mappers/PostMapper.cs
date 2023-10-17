using Application.Dtos;
using Application.Entities;
using AutoMapper;

namespace Application.Mappers
{
	public class PostMapper : Profile
	{
        public PostMapper()
        {
            CreateMap<AddPost, Post>();
            CreateMap<User, PostResponseDto>();
			CreateMap<Category, PostResponseDto>();
            CreateMap<Post, PostResponseDto>()
                .IncludeMembers(x => x.Category, x => x.User)
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(source => source.Category.Name))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(source => source.User.UserName));
		}
    }
}
