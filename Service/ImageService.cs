using Application.Interfaces.Services;
using Application.ValueObjects;
using ImageProcessor;

namespace Service
{
	public class ImageService : IImageService
	{
		public Dimension GetDimension(Stream image)
		{
			using (var imageFactory = new ImageFactory())
			{
				imageFactory.Load(image).AutoRotate();
				return new Dimension( imageFactory.Image.Height, imageFactory.Image.Width );
			}
		}
	}
}
