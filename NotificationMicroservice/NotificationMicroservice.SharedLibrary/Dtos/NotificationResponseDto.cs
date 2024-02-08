using SharedLibrary.Dtos;

namespace NotificationMicroservice.SharedLibrary.Dtos
{
    public class NotificationResponseDto<T> : BaseResponseDto<string>
    {
        public int OwnerId { get; set; }
        public T Content { get; set; }
        public DateTime? ViewedDate { get; set; }
        public bool IsViewed { get; set; }
    }
}
