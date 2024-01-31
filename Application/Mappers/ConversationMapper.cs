using AutoMapper;
using Models.Dtos;
using Models.Entities;

namespace Application.Mappers
{
	public class ConversationMapper : Profile
	{
        public ConversationMapper()
        {
            CreateMap<Conversation, ConversationResponseDto>();
        }
    }
}
