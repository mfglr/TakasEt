using AutoMapper;
using ChatMicroservice.Application.Dtos;
using ChatMicroservice.Domain.MessageEntity;

namespace ChatMicroservice.Application.Mappers
{
	public class MessageMapper : Profile
	{
        public MessageMapper()
        {
            CreateMap<Message,MessageResponseDto>();
        }
    }
}
