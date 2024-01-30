namespace Models.ValueObjects
{
	public class ContainerName
	{
        public string Value { get; private set; }
        private ContainerName(string value){ Value = value; }

        public static readonly ContainerName PostImage = new ContainerName("post-image");
		public static readonly ContainerName UserImage = new ContainerName("user-image");
        public static readonly ContainerName GroupImage = new ContainerName("group-image");
		public static readonly ContainerName StoryImage = new ContainerName("story-image");
		public static readonly ContainerName MessageImage = new ContainerName("message-image");
	}
}
