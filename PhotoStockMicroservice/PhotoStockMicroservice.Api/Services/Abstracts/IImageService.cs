using SharedLibrary.ValueObjects;

namespace PhotoStockMicroservice.Api.Services.Abstracts
{
    public interface IImageService
    {
        Dimension GetDimension(Stream image);
    }
}
