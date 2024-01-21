namespace Application.Entities
{
	public class PostImage : Entity
	{

        public int Id { get; private set; }

        public string BlobName { get; private set; }
        public string Extention { get; private set; }
        public string ContainerName { get; private set; }
        public int PostId { get; private set; }
		public Post Post { get; }
        public int Index { get; private set; }

		public override int[] GetKey()
		{
			return new[] { Id };
		}

		public PostImage() { }

        public PostImage(string blobName, string extention,int index)
        {
            BlobName = blobName;
            Extention = extention;
            ContainerName = ValueObjects.ContainerName.PostImage.Value;
            Index = index;
        }

		
	}
}
