using AutoMapper;
using ConversationService.Application.Dtos;
using ConversationService.Domain.MessageAggregate;

namespace ConversationService.Application.Mappers
{
    public class MessageMappers : Profile
    {
        public MessageMappers()
        {
            CreateMap<Message, MessageResponseDto>()
                .ForMember(x => x.Status, x => x.MapFrom(x => x.MessageState.Status));
            
            CreateMap<MessageImage, MessageImageResponseDto>()
                .ForMember(x => x.ContainerName, x => x.MapFrom(x => x.ContainerName.Value))
                .ForMember(x => x.AspectRatio, x => x.MapFrom(x => x.Dimension.AspectRatio))
                .ForMember(x => x.Height, x => x.MapFrom(x => x.Dimension.Height))
                .ForMember(x => x.Width, x => x.MapFrom(x => x.Dimension.Width));
        }

    }



}
