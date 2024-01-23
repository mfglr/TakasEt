namespace Application.ValueObjects
{
	public class ContainerName
	{
        public string Value { get; private set; }
        private ContainerName(string value){ Value = value; }

        public static readonly ContainerName PostImage = new ContainerName("post-image");
		public static readonly ContainerName UserImage = new ContainerName("user-image");
        public static readonly ContainerName ConversationImage = new ContainerName("conversation-image");
	}
}
