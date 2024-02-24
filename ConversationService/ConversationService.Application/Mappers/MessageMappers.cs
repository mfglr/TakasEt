using AutoMapper;
using ConversationService.Application.Dtos;
using ConversationService.Domain.ConversationAggregate;

namespace ConversationService.Application.Mappers
{
    public class MessageMappers : Profile
    {
        public MessageMappers()
        {
            CreateMap<Message, MessageResponseDto>();
        }

    }
}
