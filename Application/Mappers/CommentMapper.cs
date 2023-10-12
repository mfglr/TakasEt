using Application.Dtos;
using Application.Entities;
using AutoMapper;

namespace Application.Mappers
{
	public class CommentMapper : Profile
	{
        public CommentMapper()
        {
            CreateMap<AddComment, Comment>();
            CreateMap<Comment,CommentResponseDto>();
        }
    }
}
