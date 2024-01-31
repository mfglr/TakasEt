using Models.ValueObjects;

namespace Models.Interfaces.Services
{
	public interface IImageService
	{
		Dimension GetDimension(Stream image);
	}
}
