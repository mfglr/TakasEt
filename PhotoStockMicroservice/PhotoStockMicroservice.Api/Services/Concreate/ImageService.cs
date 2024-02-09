using ImageProcessor;
using PhotoStockMicroservice.Api.Services.Abstracts;
using SharedLibrary.ValueObjects;

namespace PhotoStockMicroservice.Api.Services.Concreate
{
    public class ImageService : IImageService
    {
        public Dimension GetDimension(Stream image)
        {
            using (var imageFactory = new ImageFactory())
            {
                imageFactory.Load(image).AutoRotate();
                return new Dimension(imageFactory.Image.Height, imageFactory.Image.Width);
            }
        }
    }
}
