using Application.ValueObjects;

namespace Application.Entities
{
	public class UserImage : Image
	{
		public bool IsActive { get; private set; }
		public int UserId { get; private set; }
		
		public User User { get; }

		public UserImage() { }

		public UserImage(string blobName, string extention,Dimension dimension) : base(ContainerName.UserImage,blobName,extention,dimension)
		{
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
