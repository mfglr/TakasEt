using AutoMapper;
using ConversationService.Application.Dtos;
using ConversationService.Domain.ConversationAggregate;

namespace ConversationService.Application.Mappers
{
    public class MessageMappers : Profile
    {
        public MessageMappers()
        {
            CreateMap<Message, MessageResponseDto>()
                .ForMember(x => x.Status,x => x.MapFrom(x => x.State.Status));
        }

    }
}
