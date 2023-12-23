namespace Application.ValueObjects
{
	public class ContainerName
	{
        public string Value { get; private set; }
        public ContainerName(string value)
        {
            Value = value;
        }
        public static readonly ContainerName PostImage = new ContainerName("post-image");
		public static readonly ContainerName ProfileImage = new ContainerName("user-image");
        public bool Equal(ContainerName other) => Value == other.Value;
        public bool Equal(string other) => Value == other;
	}
}
