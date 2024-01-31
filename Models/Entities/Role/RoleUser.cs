namespace Models.Entities
{
    public class RoleUser : CrossEntity<Role,User>
    {
		public override int[] GetKey() => new int[] { RoleId, UserId };
		public int RoleId { get; private set; }
		public int UserId { get; private set; }

        public User User { get; }
        public Role Role { get; }

        public RoleUser(int roleId, int userId)
        {
			RoleId = roleId;
			UserId = userId;
        }
    }
}
