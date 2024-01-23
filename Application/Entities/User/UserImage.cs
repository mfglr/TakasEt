using Application.ValueObjects;

namespace Application.Entities
{
	public class UserImage : Entity, IImage
	{
		public bool IsActive { get; private set; }
		public int UserId { get; private set; }
		public User User { get; }
		public string BlobName { get; private set; }
        public string Extention { get; private set; }
		public ContainerName ContainerName { get; private set; }
		public Dimension Dimension { get; private set; }

		public UserImage() { }

		public UserImage(int userId, string blobName, string extention,Dimension dimension)
		{
			BlobName = blobName;
			Extention = extention;
			UserId = userId;
			ContainerName = ContainerName.UserImage;
			Dimension = dimension;
		}

		public void Activate()
		{
			IsActive = true;
		}

		public void Deactivate()
		{
			IsActive = false;
		}
		
	}
}
