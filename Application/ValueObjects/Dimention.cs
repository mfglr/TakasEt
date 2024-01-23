namespace Application.ValueObjects
{
	public class Dimension
	{
		public int Height { get; private set; }
		public int Width { get; private set; }

		public Dimension(int height, int width)
		{
			Height = height;
			Width = width;
		}
	}
}
