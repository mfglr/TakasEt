using Application.ValueObjects;

namespace Application.Entities
{
	public class PostImage : Entity, IImage
	{

        public string BlobName { get; private set; }
        public string Extention { get; private set; }
        public ContainerName ContainerName { get; private set; }
        public int PostId { get; private set; }
		public Post Post { get; }
        public int Index { get; private set; }
		public Dimension Dimension { get; private set; }
		public float AspectRatio { get; private set; }

		public PostImage() { }

        public PostImage(string blobName, string extention,int index,Dimension dimention)
        {
            BlobName = blobName;
            Extention = extention;
            ContainerName = ContainerName.PostImage;
            Index = index;
            Dimension = dimention;
            AspectRatio = dimention.CalculateAspectRatio();
        }

		
	}
}
