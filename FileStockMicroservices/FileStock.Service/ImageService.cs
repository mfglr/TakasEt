using FileStock.Core.Services;
using SharedLibrary.ValueObjects;
using System.Drawing;

namespace FileStock.Service
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
