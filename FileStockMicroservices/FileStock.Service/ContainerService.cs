using FileStock.Core.Configurations;
using FileStock.Core.Services;
using SharedLibrary.Dtos;
using SharedLibrary.Exceptions;
using SharedLibrary.Helpers;
using System.Net;

namespace FileStock.Service
{
    public class ContainerService : IContainerService
    {
        private readonly IContainerSettings _containerSettings;

        public ContainerService(IContainerSettings containerSettings)
        {
            _containerSettings = containerSettings;
        }

        private string GetPath(string containerName)
        {
            return GetPathHelper.Run($"{_containerSettings.RootPath}/{containerName}");
        }

        public IAppResponseDto CreateContainer(string containerName)
        {
            var path = GetPath(containerName);
            if (Directory.Exists(path))
                throw new AppException($"The container ({containerName}) was already created!", HttpStatusCode.BadRequest);
            Directory.CreateDirectory(path);
            return new AppSuccessResponseDto();
        }
    }
}
