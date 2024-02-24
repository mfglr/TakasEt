namespace SharedLibrary.Dtos
{
    public class AppGenericSuccessResponseDto<T> : IAppResponseDto
    {
        public T Data { get; private set; }
        public bool IsError { get; private set; }
        public AppGenericSuccessResponseDto(T data) { IsError = false; Data = data; }
    }
}
