using Application.ValueObjects;

namespace Application.Entities
{
	public interface IImage
	{
		ContainerName ContainerName { get; }
		string BlobName { get; }
		string Extention { get; }
		float AspectRatio { get; }
		Dimension Dimension { get; }
	}
}
