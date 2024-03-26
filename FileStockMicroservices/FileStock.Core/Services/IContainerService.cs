using SharedLibrary.Dtos;

namespace FileStock.Core.Services
{
    public interface IContainerService
    {
        IAppResponseDto CreateContainer(string containerName);
    }
}
