using AutoMapper;
using Models.Dtos;
using Models.Entities;

namespace Application.Mappers
{
	public class MessageMapper : Profile
	{
		public MessageMapper() { 
			CreateMap<Message,MessageResponseDto>()
				.ForMember(dest => dest.Status, opt => opt.MapFrom(x => x.MessageState.Status));
		}
	}
}
