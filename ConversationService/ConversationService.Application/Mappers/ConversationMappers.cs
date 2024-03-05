using AutoMapper;
using ConversationService.Domain.ConversationAggregate;

namespace ConversationService.Application.Mappers
{
    public class ConversationMappers : Profile
    {
        public ConversationMappers()
        {
            CreateMap<Conversation, Conversation>();
        }
    }
}
