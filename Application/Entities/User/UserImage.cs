namespace Application.Entities
{
	public class UserImage : Entity
	{
		public bool IsActive { get; private set; }
		public int UserId { get; private set; }
		public User User { get; }
		public string BlobName { get; private set; }
        public string Extention { get; private set; }
		public string ContainerName { get; private set; }
        
		public UserImage() { }

		public UserImage(int userId, string blobName, string extention)
		{
			BlobName = blobName;
			Extention = extention;
			UserId = userId;
			ContainerName = ValueObjects.ContainerName.UserImage.Value;
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
