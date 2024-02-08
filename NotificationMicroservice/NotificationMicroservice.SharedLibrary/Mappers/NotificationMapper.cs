using AutoMapper;
using NotificationMicroservice.SharedLibrary.Dtos;
using NotificationMicroservice.SharedLibrary.Entities;

namespace NotificationMicroservice.SharedLibrary.Mappers
{
    public class NotificationMapper : Profile
    {
        public NotificationMapper()
        {
            CreateMap(typeof(Notification<>), typeof(NotificationResponseDto<>));
        }
    }
}
