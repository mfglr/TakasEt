namespace SharedLibrary.Dtos
{
    public class AppSuccessResponseDto : IAppResponseDto
    {
        public bool IsError { get; private set; }
        public AppSuccessResponseDto() => IsError = false;
    }
}
