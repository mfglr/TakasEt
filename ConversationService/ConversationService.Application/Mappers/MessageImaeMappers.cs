using AutoMapper;
using ConversationService.Application.Dtos;
using ConversationService.Domain.MessageAggregate;

namespace ConversationService.Application.Mappers
{
    public class MessageImaeMappers : Profile
    {
        public MessageImaeMappers()
        {
            CreateMap<MessageImage, MessageImageResponseDto>()
                .ForMember(x => x.ContainerName, x => x.MapFrom(x => x.ContainerName.Value))
                .ForMember(x => x.AspectRatio, x => x.MapFrom(x => x.Dimension.AspectRatio))
                .ForMember(x => x.Height, x => x.MapFrom(x => x.Dimension.Height))
                .ForMember(x => x.Width, x => x.MapFrom(x => x.Dimension.Width));
        }

    }
}
