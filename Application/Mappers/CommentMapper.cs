using Application.Dtos;
using Application.Entities;
using AutoMapper;

namespace Application.Mappers
{
	public class CommentMapper : Profile
	{
        public CommentMapper()
        {
            CreateMap<AddCommentDto, Comment>();
            CreateMap<User,CommentResponseDto>();
            CreateMap<Comment,CommentResponseDto>()
                .IncludeMembers(x => x.User)
                .ForMember(dest => dest.UserName,opt => opt.MapFrom(source => source.User.UserName));
        }
    }
}
