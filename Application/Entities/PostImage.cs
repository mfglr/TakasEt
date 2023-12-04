namespace Application.Entities
{
	public class PostImage : AppFile
	{

		public int PostId { get; private set; }
		public Post Post { get; }
        public int Index { get; private set; }
		
        public PostImage() { }

        public PostImage(string blobName, string extention,int index) : base(blobName, extention) 
        {
            ContainerName = ValueObjects.ContainerName.PostImage.Value;
            Index = index;
        }
    }
}
