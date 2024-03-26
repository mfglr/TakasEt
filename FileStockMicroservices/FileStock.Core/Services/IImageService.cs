using SharedLibrary.ValueObjects;

namespace FileStock.Core.Services
{
    public interface IImageService
    {
        Dimension GetDimension(Stream image);
    }
}
