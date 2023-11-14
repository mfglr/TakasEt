namespace Application.Entities
{
	public class ProfileImage : AppFile
	{
		public bool IsActive { get; private set; }
		public int? UserId { get; private set; }
		public User? User { get; }

		public ProfileImage() { }

		public ProfileImage(bool isActive, int userId, string blobName, string extention) : base( blobName, extention)
		{
			UserId = userId;
			ContainerName = ValueObjects.ContainerName.ProfileImage.Value;
			IsActive = isActive;
		}

		public void Deactivate()
		{
			IsActive = false;
		}
		public void Activate()
		{
			IsActive = true;
		}
	}
}
