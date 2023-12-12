namespace Application.Entities
{
	public class Swapping : Entity
	{
        public int PostId1 { get; private set; }
		public Post Post1 { get; }
        public int PostId2 { get; private set; }
        public Post Post2 { get; }
		public int Rate {  get; private set; }
        public IReadOnlyCollection<SwappingComment> SwappingComments { get; }

        public Swapping(int postId1, int postId2, int rate)
		{
			PostId1 = postId1;
			PostId2 = postId2;
			Rate = rate;
		}


	}
}
