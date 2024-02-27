namespace SharedLibrary.ValueObjects
{
	public class ContainerName : ValueObject
	{
        public string Value { get; private set; }
        private ContainerName(string value){ Value = value; }

        public static readonly ContainerName PostImages = new ContainerName("post-images");
		public static readonly ContainerName UserImages = new ContainerName("user-images");
        public static readonly ContainerName GroupImages = new ContainerName("group-images");
		public static readonly ContainerName StoryImages = new ContainerName("story-images");
		public static readonly ContainerName MessageImages = new ContainerName("message-images");

		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Value;
		}
	}
}
