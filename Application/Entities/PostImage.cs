namespace Application.Entities
{
	public class PostImage : AppFile
	{

		public int? PostId { get; private set; }
		public Post? Post { get; }

		public PostImage() { }
        public PostImage(int postId, string blobName, string extention) : base(blobName, extention) 
        {
            ContainerName = ValueObjects.ContainerName.PostImage.Value;
            PostId = postId;
        }
    }
}
