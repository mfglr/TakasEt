using PhotoStockMicroservice.Api.Services.Abstracts;
using SharedLibrary.ValueObjects;
using System.Drawing;

namespace PhotoStockMicroservice.Api.Services.Concreate
{
    public class ImageService : IImageService
    {
        public Dimension GetDimension(Stream image)
        {
            using var i = Image.FromStream(image);
            return new Dimension(i.Height, i.Width);
        }
    }
}
