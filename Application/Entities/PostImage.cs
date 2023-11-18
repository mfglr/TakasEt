namespace Application.Entities
{
	public class PostImage : AppFile
	{

		public int? PostId { get; private set; }
		public Post? Post { get; }
        public int Index { get; private set; }
		public PostImage() { }
        public PostImage(int postId, string blobName, string extention,int index) : base(blobName, extention) 
        {
            ContainerName = ValueObjects.ContainerName.PostImage.Value;
            PostId = postId;
            Index = index;
        }
    }
}
