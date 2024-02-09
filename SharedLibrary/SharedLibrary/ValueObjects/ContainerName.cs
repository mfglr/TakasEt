namespace SharedLibrary.ValueObjects
{
	public class ContainerName : ValueObject
	{
        public string Value { get; private set; }
        private ContainerName(string value){ Value = value; }

        public static readonly ContainerName PostImages = new ContainerName("images/post-images");
		public static readonly ContainerName UserImages = new ContainerName("images/user-images");
        public static readonly ContainerName GroupImages = new ContainerName("images/group-images");
		public static readonly ContainerName StoryImages = new ContainerName("images/story-images");
		public static readonly ContainerName MessageImages = new ContainerName("images/message-images");

		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Value;
		}
	}
}
