using AutoMapper;
using ChatMicroservice.Application.Dtos;
using ChatMicroservice.Domain.ConnectionAggregate;

namespace ChatMicroservice.Application.Mappers
{
	public class ConnectionMapper : Profile
	{
        public ConnectionMapper()
        {
            CreateMap<Connection, ConnectionResponseDto>();
        }
    }
}
