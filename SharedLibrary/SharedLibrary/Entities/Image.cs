using SharedLibrary.ValueObjects;

namespace SharedLibrary.Entities
{
	public abstract class Image<TKey> : Entity<TKey>
	{
		public ContainerName ContainerName { get; private set; }
		public string BlobName { get; private set; }
		public string Extention { get; private set; }
		public Dimension Dimension { get; private set; }

		public Image() { }

		public Image(ContainerName containerName, string blobName, string extention, Dimension dimension)
		{
			ContainerName = containerName;
			BlobName = blobName;
			Extention = extention;
			Dimension = dimension;
		}
	}

	public abstract class Image : Image<int> {

        public Image() { }

        public Image(ContainerName containerName, string blobName, string extention, Dimension dimension)
        : base(containerName, blobName, extention, dimension)
		{

		}

    }

}
