using AutoMapper;
using ConversationService.Application.Dtos;
using ConversationService.Domain.MessageEntity;

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
