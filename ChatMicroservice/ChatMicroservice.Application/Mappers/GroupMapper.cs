using AutoMapper;
using ChatMicroservice.Application.Dtos;
using ChatMicroservice.Application.Dtos.Group;
using ChatMicroservice.Domain.GroupAggregate;

namespace ChatMicroservice.Application.Mappers
{
	public class GroupMapper : Profile
	{
        public GroupMapper()
        {
            CreateMap<Group, GroupResponseDto>();
            CreateMap<GroupUser, GroupUserResponseDto>();
        }
    }
}
