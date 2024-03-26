namespace SharedLibrary.ValueObjects
{
	public class ContainerName : ValueObject
	{
        public string Value { get; private set; }
        private ContainerName(string value){ Value = value; }

        public static readonly ContainerName PostImages = new ("post-images");
		public static readonly ContainerName UserImages = new ("user-images");
        public static readonly ContainerName GroupImages = new ("group-images");
		public static readonly ContainerName StoryImages = new ("story-images");
		public static readonly ContainerName MessageImages = new ("message-images");

		public static ContainerName CreateContainerName(ContainerName containerName) => new (containerName.Value);

		protected override IEnumerable<object> GetEqualityComponents()
		{
			yield return Value;
		}
	}
}
