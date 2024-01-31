using Models.Interfaces.Services;
using ImageProcessor;
using Models.ValueObjects;

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
