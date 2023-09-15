using Application.ValueObjects;

namespace Application.Entities
{
	public class ProfilePicture : Entity
	{
        public Guid UserId { get; private set; }
		public User User { get; private set; }
		public AppFile Image { get; private set; }
        public bool IsDisplayed { get; private set; } = true;

		public void Display()
		{
			IsDisplayed = true;
		}
		public void NotDisplay()
		{
			IsDisplayed = false;
		}
    }
}
