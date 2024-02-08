using SharedLibrary.Dtos;

namespace NotificationMicroservice.Api.Models.Dtos
{
    public class NotificationResponseDto : BaseResponseDto
    {
        public int OwnerId { get; set; }
        public string NotificationContainerId { get; set; }
    }
}
