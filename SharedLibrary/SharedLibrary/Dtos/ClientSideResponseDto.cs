namespace SharedLibrary.Dtos
{
    public class ClientSideResponseDto<T>
    {
        public bool IsError { get; set; }
        public List<string>? Errors { get; set; }
        public T? Data { get; set; }
    }
}
