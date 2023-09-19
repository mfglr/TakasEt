namespace Application.ValueObjects
{
	public class ContainerName
	{
        public string Value { get; private set; }
        private ContainerName(string value)
        {
            Value = value;
        }
        public static readonly ContainerName PostImage = new ContainerName("post-image");
		public static readonly ContainerName ProfileImage = new ContainerName("profile-image");
	}
}
