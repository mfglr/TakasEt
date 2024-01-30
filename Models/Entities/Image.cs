using Models.ValueObjects;

namespace Models.Entities
{
    public abstract class Image : Entity
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
}
