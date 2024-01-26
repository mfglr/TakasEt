using Models.ValueObjects;

namespace Application.Interfaces.Services
{
	public interface IImageService
	{
		Dimension GetDimension(Stream image);
	}
}
