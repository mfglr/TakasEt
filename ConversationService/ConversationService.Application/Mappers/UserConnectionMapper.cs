using AutoMapper;
using ConversationService.Application.Dtos;
using ConversationService.Domain.UserConnectionAggregate;

namespace ConversationService.Application.Mappers
{
    public class UserConnectionMapper : Profile
    {
        public UserConnectionMapper()
        {
            CreateMap<UserConnection,UserConnectionResponseDto>();
        }
    }
}
