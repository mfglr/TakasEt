namespace Models.Entities
{
    public class UserUserViewing : CrossEntity
    {
		public override int[] GetKey() => new[] { ViewerId, ViewedId };
		public int ViewerId { get; private set; }
        public int ViewedId { get; private set; }

        public User Viewer { get; }
        public User Viewed { get; }

        public UserUserViewing(int viewerId, int viewedId)
        {
			ViewerId = viewerId;
            ViewedId = viewedId;
        }


    }
}
