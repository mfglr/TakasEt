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
            CreateMap<Group, GroupResponseDto>()
                .ForMember(
                    x => x.NumberOfUnviewedMessages,
                    x => x.MapFrom(x => x.Messages.Count())
                );
            CreateMap<GroupUser, GroupUserResponseDto>();
        }
    }
}
