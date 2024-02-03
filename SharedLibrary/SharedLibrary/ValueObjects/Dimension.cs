namespace SharedLibrary.ValueObjects
{
	public class Dimension : ValueObject
	{
		public int Height { get; private set; }
		public int Width { get; private set; }
		public float AspectRatio { get; private set; }

		public Dimension(int height, int width)
		{
			Height = height;
			Width = width;
			AspectRatio = width / height;
		}
		
	}
}
