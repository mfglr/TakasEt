namespace Application.Entities
{
	public class PostImage : AppFile
	{

		public Guid? PostId { get; private set; }
		public Post? Post { get; }

		public PostImage() { }
        public PostImage(Guid postId, string blobName, string extention) : base(blobName, extention) 
        {
            ContainerName = ValueObjects.ContainerName.PostImage.Value;
            PostId = postId;
        }
    }
}
